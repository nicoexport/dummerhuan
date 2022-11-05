using System;
using System.Collections;
using Dummerhuan.Combat;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan.MiniGames {
    public class MarkerMinigame : MonoBehaviour, IMiniGame {
        [Header("Minigame Values")]
        [Range(0f, 1f)] public float goodPartValue;
        [Range(0f, 1f)] public float perfectPartValue;

        [Header("Minigame Results")] [SerializeField]
        private float[] damageValues;

        [Header("Reference")] public Animator marker;
        public Transform markerPos;
        public Transform goodPart;
        public Transform perfectPart;

        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private bool finished = false;

        protected void OnValidate() {
            AdjustBars();
        }

        protected void Update() {
            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.wasPressedThisFrame) {
                Evaluate();
            }
        }

        private void Evaluate() {
            marker.StartPlayback();
            CheckMarkerPos();
        }

        private void AdjustBars() {
            var gScale = goodPart.localScale;
            gScale.x = goodPartValue;

            goodPart.localScale = gScale;

            var pScale = perfectPart.localScale;
            pScale.x = perfectPartValue;

            perfectPart.localScale = pScale;
        }

        private void CheckMarkerPos() {
            float[] breakPoints = new float[3];
            breakPoints[0] = perfectPart.localScale.x / 2;
            breakPoints[1] = goodPart.localScale.x / 2;
            breakPoints[2] = 0.5f;
            float checkX = Mathf.Abs(markerPos.localPosition.x);

            for (int i = 0; i < breakPoints.Length; i++) {
                if (checkX < Mathf.Abs(breakPoints[i])) {
                    playerCurrentHealth.Value -= damageValues[i];
                    finished = true;
                    return;
                }
            }
        }

        public void Setup(Effectiveness effectiveness) {
            var gLocalScale = goodPart.localScale;
            var pLocalScale = perfectPart.localScale;
            switch (effectiveness) {
                case Effectiveness.Resist:
                    goodPart.localScale = new Vector3(gLocalScale.x * 0.5f, gLocalScale.y, gLocalScale.z);
                    perfectPart.localScale = new Vector3(pLocalScale.x * 0.5f, pLocalScale.y, pLocalScale.z);
                    break;
                case Effectiveness.Weak:
                    goodPart.localScale = new Vector3(gLocalScale.x * 1.5f, gLocalScale.y, gLocalScale.z);
                    perfectPart.localScale = new Vector3(pLocalScale.x * 1.5f, pLocalScale.y, pLocalScale.z);
                    break;
                case Effectiveness.Neutral:
                    break;
            }
        }

        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            End();
        }

        public void End() => Destroy(gameObject);
    }
}