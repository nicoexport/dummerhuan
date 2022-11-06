using UnityEngine;

namespace Dummerhuan {
    public class MoleEnemy : MonoBehaviour {
        private WhackAMoleMinigame whackAMoleMinigame;
        private bool isHit;

        private void Awake() {
            whackAMoleMinigame = GetComponentInParent<WhackAMoleMinigame>();
        }

        private void OnEnable() {
            isHit = false;
        }

        private void Hit() {
            if (isHit) {
                return;
            }
            whackAMoleMinigame.DamageTaken();
            isHit = true;
        }
    }
}
