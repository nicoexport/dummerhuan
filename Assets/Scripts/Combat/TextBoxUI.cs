using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Dummerhuan.Combat {
    public class TextBoxUI : MonoBehaviour {
        [SerializeField] private RectTransform panel;
        [SerializeField] private TextMeshProUGUI textMesh;

        public UnityEvent OnDisplayCharacter;

        protected void Awake() {
            panel.gameObject.SetActive(false);
        }

        public IEnumerator DisplayText_Co(string speaker, string message, float timeInSecondsPerChar) {
            panel.gameObject.SetActive(true);
            var builder = new StringBuilder();
            builder.Append(speaker + ": ");
            textMesh.text = builder.ToString();
            yield return new WaitForSeconds(timeInSecondsPerChar);
            
            foreach (char c in message)
            {
                yield return new WaitForSeconds(timeInSecondsPerChar);
                builder.Append(c);
                textMesh.text = builder.ToString();
                OnDisplayCharacter?.Invoke();
            }

            yield return new WaitForSeconds(1f);
            panel.gameObject.SetActive(false);
        }
    }
}