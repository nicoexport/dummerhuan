using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan.Combat {
    public class TestPlayer : MonoBehaviour {
        [SerializeField] private FloatReference maxHealth;
        [SerializeField] private FloatReference currentHealth;

        protected void Start() {
            currentHealth.Value = maxHealth.Value;
        }

        protected void Update() {
            var keyboard = Keyboard.current;

            if (keyboard.aKey.wasPressedThisFrame) {
                ChangeHealth(-10f);
            }
            
            if (keyboard.dKey.wasPressedThisFrame) {
                ChangeHealth(10f);
            }
        }

        public void OnHealthChanged() {
            if (currentHealth.Value <= 0) {
                Destroy(gameObject);
            }
        }
        
        private void ChangeHealth(float amount) {
            currentHealth.Value += amount;
        }

        
    }
}