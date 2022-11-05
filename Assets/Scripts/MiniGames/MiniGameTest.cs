using System.Collections;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan.MiniGames {
    public class MiniGameTest : MonoBehaviour, IMiniGame {

        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private bool finished = false; 

        protected void Update() {
            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.wasPressedThisFrame) {
                finished = true;
            }
        }
        
        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            playerCurrentHealth.Value -= 10f;
            yield return new WaitForSeconds(0.5f);
            End();
        }

        public void End() => Destroy(gameObject);
    }
}