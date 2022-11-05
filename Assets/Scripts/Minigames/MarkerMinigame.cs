using System.Collections;
using Dummerhuan.MiniGames;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan {
    public class MarkerMinigame : MonoBehaviour, IMiniGame {
        [Header("Minigame Values")]
        [Range(-1, 1)]
        public int effectivness;
        [Range(0f, 1f)]
        public float goodPartValue;
        [Range(0f, 1f)]
        public float perfectPartValue;

        [Header("Minigame Results")]
        [SerializeField] private float[] damageValues;

        [Header("Reference")]
        public Animator marker;
        public Transform markerPos;
        public Transform goodPart;
        public Transform perfectPart;

        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private bool finished = false;

        protected void Start() {

        }

        protected void Update() {
            AdjustBars();

            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.wasPressedThisFrame) {
                Evaluate();
            }
        }

        protected void Evaluate() {
            marker.StartPlayback();
            CheckMarkerPos();
        }

        protected void AdjustBars() {
            var gScale = goodPart.localScale;
            gScale.x = goodPartValue;

            goodPart.localScale = gScale;

            var pScale = perfectPart.localScale;
            pScale.x = perfectPartValue;

            perfectPart.localScale = pScale;
        }

        protected void CheckMarkerPos() {
            float[] breakPoints = new float[3];
            breakPoints[0] = perfectPart.localScale.x / 2;
            breakPoints[1] = goodPart.localScale.x / 2;
            breakPoints[2] = 0.5f;
            float checkX = Mathf.Abs(markerPos.localPosition.x);

            for (int i = 0; i < breakPoints.Length; i++) {
                if (checkX < Mathf.Abs(breakPoints[i])) {
                    playerCurrentHealth.Value -= damageValues[i];
                }
            }
            finished = true;
        }
        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            End();
        }

        public void End() => Destroy(gameObject);
    }
}
