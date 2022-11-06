using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dummerhuan.Audio {
    [CreateAssetMenu(fileName = "new AudioCue", menuName = "Audio/AudioCue", order = 0)]
    public class AudioCueSo : ScriptableObject {
        public bool Looping;
        [SerializeField] private AudioClipGroup[] _audioClipGroup;

        public AudioClip[] GetClips() {
            int numberOfClips = _audioClipGroup.Length;
            var resultingClips = new AudioClip[numberOfClips];

            for (int i = 0; i < numberOfClips; i++) {
                resultingClips[i] = _audioClipGroup[i].GetNextClip();
            }

            return resultingClips;
        }
    }

    [Serializable]
    public class AudioClipGroup {
        public enum SequenceMode {
            Random,
            RandomNoImmediateRepeat,
            Sequential
        }

        public SequenceMode Mode;
        public AudioClip[] Clips;
        private int _lastClip;

        private int _nextClip;

        public AudioClip GetNextClip() {
            if (Clips.Length == 1) {
                return Clips[0];
            }

            if (_nextClip == -1) {
                _nextClip = Mode == SequenceMode.Sequential ? 0 : Random.Range(0, Clips.Length);
            } else {
                switch (Mode) {
                    case SequenceMode.Random:
                        _nextClip = Random.Range(0, Clips.Length);
                        break;

                    case SequenceMode.RandomNoImmediateRepeat:
                        do {
                            Random.Range(0, Clips.Length);
                        } while (_nextClip == _lastClip);

                        break;

                    case SequenceMode.Sequential:
                        _nextClip = (int)Mathf.Repeat(++_nextClip, Clips.Length);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _lastClip = _nextClip;
            return Clips[_nextClip];
        }
    }
}