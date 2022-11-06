using Dummerhuan.Audio;
using Dummerhuan.References;
using UnityEngine;

namespace Dummerhuan.Combat {
    public class EnemySpeaker : MonoBehaviour {
        [SerializeField] private EnemySOReference currentEnemy;
        [SerializeField] private AudioCue speakerAudio;

        protected void OnEnable() {
            OnEnemyChanged();
        }

        public void OnEnemyChanged() {
            speakerAudio.Config = currentEnemy.Value.speakerConfig;
        }
    }   
}