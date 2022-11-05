using System.Collections;
using Dummerhuan.Combat;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan.MiniGames {
    public class MiniGameTest : MonoBehaviour, IMiniGame {

        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private bool finished = false;
        [SerializeField] private float damage = 40f;

        protected void Update() {
            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.wasPressedThisFrame) {
                finished = true;
            }
        }

        public void Setup(Effectiveness effectiveness) {
            
        }

        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            playerCurrentHealth.Value -= damage;
            yield return new WaitForSeconds(0.5f);
            End();
        }

        public void End() => Destroy(gameObject);
    }
}