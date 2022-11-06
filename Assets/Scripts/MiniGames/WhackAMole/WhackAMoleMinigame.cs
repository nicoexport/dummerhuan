using System;
using System.Collections;
using Dummerhuan.Combat;
using Dummerhuan.MiniGames;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Dummerhuan {
    public class WhackAMoleMinigame : MonoBehaviour, IMiniGame {

        private int damageTaken;
        private int damageBreakpoint;
        
        [SerializeField] private Animator[] moles;

        public float enemyMoleChance = 0.7f;

        public int healValue = 2;
        public int damageValue = 3;
        private Camera cam;

        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private float[] durationsInSeconds;
        private bool finished;

        public float moleRate = 1f;
        private float nextMole;

        protected void Awake() {
            cam = Camera.main;
        }

        void Update() {
            var mouse = Mouse.current;
            Vector3 mousePos = mouse.position.ReadValue();


            var hit = Physics2D.Raycast(mousePos, mousePos - cam.ScreenToWorldPoint(mousePos) );
            if (mouse.leftButton.wasPressedThisFrame) {
                if (hit) {
                    Debug.Log(hit.collider.gameObject);
                }
            }
            

            if (Time.time > nextMole) {
                Mole();
            }
        }

        private void Mole() {
            if (!finished) {
                var randomMole = Random.Range(0, moles.Length);

                var moleType = Random.Range(0, 1);

                if (moleType >= enemyMoleChance) {
                    moles[randomMole].SetTrigger("Enemy");
                } else {
                    moles[randomMole].SetTrigger("Friend");
                }

                nextMole = Time.time + moleRate;
            }
        }

        public void DamageTaken() {
            playerCurrentHealth.Value -= damageValue;

            damageTaken++;

            if (damageTaken >= damageBreakpoint) {
                finished = true;
            }
        }

        public void DamageHealed() {
            playerCurrentHealth.Value += healValue;
        }

        public void Setup(Effectiveness effectiveness) {
            var duration = durationsInSeconds[(int)effectiveness];
            StartCoroutine(CountDown_Co(duration));
        }

        private string CountDown_Co(object duration) => throw new NotImplementedException();

        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            End();
        }

        public void End() {
            Destroy(gameObject);
        }
    }
}
