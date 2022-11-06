using System.Collections;
using System.Text;
using Dummerhuan.Combat;
using UnityEngine;

namespace Dummerhuan.Overworld {
    public class FlippableTextBoxUI : TextBoxUI {

        public IEnumerator DisplayText_Co(string message, bool flip, float timeInSecondsPerChar) {
            panel.gameObject.SetActive(true);
            if (flip) {
                Flip();
            }
            textMesh.text = "";
            var builder = new StringBuilder();

            yield return new WaitForSeconds(timeInSecondsPerChar);
            
            foreach (char c in message)
            {
                yield return new WaitForSeconds(timeInSecondsPerChar);
                builder.Append(c);
                textMesh.text = builder.ToString();
                OnDisplayCharacter?.Invoke();
            }

            yield return new WaitForSeconds(2.5f);
            panel.gameObject.SetActive(false);
        }

        private void Flip() {
            var panelScale = panel.localScale;
            panelScale.x = - panelScale.x;
            panel.localScale = panelScale;
            var textScale = textMesh.rectTransform.localScale;
            textScale.x = -textScale.x;
            textMesh.rectTransform.localScale = textScale;
        }
    }
}