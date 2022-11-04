using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan {
    public class TestPlayer : MonoBehaviour {
        [SerializeField] private IntReference maxHealth;
        [SerializeField] private IntReference currentHealth;

        protected void Start() {
            currentHealth.Value = maxHealth.Value;
        }
    }
}