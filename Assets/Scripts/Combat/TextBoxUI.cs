using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dummerhuan.Combat {
    public class TextBoxUI : MonoBehaviour {
        [SerializeField] private RectTransform panel;
        [SerializeField] private TextMeshProUGUI textMesh;

        protected void Awake() {
            panel.gameObject.SetActive(false);
        }

        public IEnumerator DisplayText_Co(string text, float timeInSeconds) {
            panel.gameObject.SetActive(true);
            textMesh.text = text;
            yield return new WaitForSeconds(timeInSeconds);
            panel.gameObject.SetActive(false);
        }
    }
}