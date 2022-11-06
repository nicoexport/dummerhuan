using UnityEngine;
using UnityEngine.Audio;

namespace Dummerhuan.Audio {
    [CreateAssetMenu(fileName = "new Audio Config", menuName = "Audio/AudioConfig", order = 0)]
    public class AudioConfigSo : ScriptableObject {
        public AudioMixerGroup OutputAudioMixerGroup;
        [SerializeField] private PriorityLevel _priorityLevel = PriorityLevel.Standard;

        [Header("Sound properties")] public bool Mute;

        [Range(0f, 1f)] public float Volume = 1f;
        [Range(-3f, 3f)] public float PitchMin = 1f;
        [Range(-3f, 3f)] public float PitchMax = 1f;
        [Range(-1f, 1f)] public float PanStereo;
        [Range(0f, 1.1f)] public float ReverbZoneMix = 1f;

        [Header("Spatial settings")] [Range(0f, 1f)]
        public float SpatialBlend;

        [Range(0f, 5f)] public float DopplerLevel = 1f;
        [Range(0f, 360f)] public float Spread;
        public AudioRolloffMode RolloffMode = AudioRolloffMode.Logarithmic;
        [Range(0.1f, 5f)] public float MinDistance = 0.1f;
        [Range(5f, 100f)] public float MaxDistance = 50f;

        [Header("Ignores")] public bool BypassEffects;

        public bool BypassListenerEffects;
        public bool BypassReverbZones;
        public bool IgnoreListenerVolume;
        public bool IgnoreListenerPause;

        [HideInInspector]
        public int Priority {
            get => (int)_priorityLevel;
            set => _priorityLevel = (PriorityLevel)value;
        }

        public void ApplyConfigToAudioSource(AudioSource audioSource) {
            audioSource.outputAudioMixerGroup = OutputAudioMixerGroup;
            audioSource.mute = Mute;
            audioSource.bypassEffects = BypassEffects;
            audioSource.bypassListenerEffects = BypassListenerEffects;
            audioSource.bypassReverbZones = BypassReverbZones;
            audioSource.priority = Priority;
            audioSource.volume = Volume;
            float pitch = Random.Range(PitchMin, PitchMax);
            audioSource.pitch = pitch;
            audioSource.panStereo = PanStereo;
            audioSource.spatialBlend = SpatialBlend;
            audioSource.reverbZoneMix = ReverbZoneMix;
            audioSource.dopplerLevel = DopplerLevel;
            audioSource.spread = Spread;
            audioSource.rolloffMode = RolloffMode;
            audioSource.minDistance = MinDistance;
            audioSource.maxDistance = MaxDistance;
            audioSource.ignoreListenerVolume = IgnoreListenerVolume;
            audioSource.ignoreListenerPause = IgnoreListenerPause;
        }

        private enum PriorityLevel {
            Highest = 0,
            High = 64,
            Standard = 128,
            Low = 194,
            Lowest = 256
        }
    }
}