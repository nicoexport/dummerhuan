using System;
using System.Collections;
using Dummerhuan.Pooling;
using MyBox;
using UnityEngine;

namespace Dummerhuan.Audio {
    public class AudioManager : Singleton<AudioManager> {
        [SerializeField] private AudioCueChannelSO _sfxChannel;
        [SerializeField] private AudioCueChannelSO _musicChannel;
        [SerializeField] private GameObject _soundEmitterPrefab;
        [SerializeField] private float _musicFadeDuration = 1f;
        private SoundEmitter _currentMusicTrack;
        private GameObjectPool _soundEmitterPool;

        protected void Awake() {
            _soundEmitterPool = new GameObjectPool(transform, _soundEmitterPrefab, 12);
        }

        private void OnEnable() {
            _sfxChannel.OnAudioCueRequested += PlayAudioCue;
            _musicChannel.OnAudioCueRequested += PlayMusic;
        }

        private void OnDisable() {
            _sfxChannel.OnAudioCueRequested -= PlayAudioCue;
            _musicChannel.OnAudioCueRequested -= PlayMusic;
        }

        private void PlayAudioCue(AudioCueRequestData audioCueRequestData) {
            var clipsToPlay = audioCueRequestData.AudioCue.GetClips();
            int numberOfClips = clipsToPlay.Length;

            for (int i = 0; i < numberOfClips; i++) {
                var soundEmitter = _soundEmitterPool.Request().GetComponent<SoundEmitter>();

                if (soundEmitter == null) {
                    return;
                }

                soundEmitter.PlayAudioClip(clipsToPlay[i], audioCueRequestData.AudioConfig,
                    audioCueRequestData.AudioCue.Looping, audioCueRequestData.Position);

                if (!audioCueRequestData.AudioCue.Looping) {
                    soundEmitter.OnSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
                }
            }
        }

        private void PlayMusic(AudioCueRequestData audioCueRequestData) {
            var clipsToPlay = audioCueRequestData.AudioCue.GetClips();
            int numberOfClips = clipsToPlay.Length;

            for (int i = 0; i < numberOfClips; i++) {
                var soundEmitter = _soundEmitterPool.Request().GetComponent<SoundEmitter>();
                if (!soundEmitter) {
                    return;
                }

                if (_currentMusicTrack != null && _currentMusicTrack.IsPlaying()) {
                    FadeOut(_currentMusicTrack, _musicFadeDuration, obj => { _soundEmitterPool.Return(obj); });
                }

                _currentMusicTrack = soundEmitter;
                _currentMusicTrack.PlayAudioClip(clipsToPlay[i], audioCueRequestData.AudioConfig,
                    audioCueRequestData.AudioCue.Looping, audioCueRequestData.Position);
                FadeIn(_currentMusicTrack, audioCueRequestData.AudioConfig.Volume, _musicFadeDuration);

                if (!audioCueRequestData.AudioCue.Looping) {
                    soundEmitter.OnSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
                }
            }
        }

        private void FadeOut(SoundEmitter soundEmitter, float durationInSeconds,
            Action<GameObject> fadeOutFinished = default) =>
            StartCoroutine(FadeOutEnumerator(soundEmitter, durationInSeconds, fadeOutFinished));

        private IEnumerator FadeOutEnumerator(SoundEmitter soundEmitter, float durationInSeconds,
            Action<GameObject> fadeOutFinished) {
            for (float volume = soundEmitter.GetVolume(); volume > 0; volume -= Time.deltaTime / durationInSeconds) {
                soundEmitter.SetVolume(volume);
                yield return null;
            }

            fadeOutFinished?.Invoke(soundEmitter.gameObject);
        }

        private void FadeIn(SoundEmitter soundEmitter, float volume, float durationInSeconds,
            Action<GameObject> fadeInFinished = default) =>
            StartCoroutine(FadeInEnumerator(soundEmitter, volume, durationInSeconds, fadeInFinished));

        private IEnumerator FadeInEnumerator(SoundEmitter soundEmitter, float volume, float durationInSeconds,
            Action<GameObject> fadeInFinished) {
            for (float vol = 0; vol < volume; vol += Time.deltaTime / durationInSeconds) {
                soundEmitter.SetVolume(volume);
                yield return null;
            }

            fadeInFinished?.Invoke(soundEmitter.gameObject);
        }

        public void PauseMusic() {
            if (!_currentMusicTrack) {
                return;
            }

            _currentMusicTrack.Pause();
        }

        public void ResumeMusic() {
            if (!_currentMusicTrack) {
                return;
            }

            _currentMusicTrack.Resume();
        }

        public void StopMusic() {
            if (!_currentMusicTrack) {
                return;
            }

            FadeOut(_currentMusicTrack, 0.5f, o => { _soundEmitterPool.Return(o); });
        }

        private void OnSoundEmitterFinishedPlaying(SoundEmitter soundEmitter) {
            soundEmitter.OnSoundFinishedPlaying -= OnSoundEmitterFinishedPlaying;
            soundEmitter.Stop();
            _soundEmitterPool.Return(soundEmitter.gameObject);
        }
    }
}