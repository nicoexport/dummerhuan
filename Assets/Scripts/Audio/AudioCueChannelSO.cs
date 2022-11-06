using System;
using UnityEngine;

namespace Dummerhuan.Audio {
    [CreateAssetMenu(fileName = "new AudioCueChannel", menuName = "Channels/AudioCueChannel", order = 0)]
    public class AudioCueChannelSO : ScriptableObject {
        public event Action<AudioCueRequestData> OnAudioCueRequested;

        public void RequestAudio(AudioCueRequestData audioCueRequestData) =>
            OnAudioCueRequested?.Invoke(audioCueRequestData);
    }

    public readonly struct AudioCueRequestData {
        public AudioCueRequestData(AudioCueSo audioCue, AudioConfigSo audioConfig, Vector3 position = default) {
            AudioCue = audioCue;
            AudioConfig = audioConfig;
            Position = position;
        }

        public readonly AudioCueSo AudioCue;
        public readonly AudioConfigSo AudioConfig;
        public readonly Vector3 Position;
    }
}