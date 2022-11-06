using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dummerhuan.Overworld {
    public class EncounterManager : MonoBehaviour {
        [SerializeField] private DialogSO currentDialog;
        [SerializeField] private FlippableTextBoxUI textBoxUI;
        [SerializeField] private float timeInSecondsPerChar = 0.08f;
        [SerializeField] private int combatSceneIndex = 1;
        private Speaker lastSpeaker = Speaker.None;

        public void StartDialog() {
            StartCoroutine(DisplayDialog_Co());
        }
        
        private IEnumerator DisplayDialog_Co() {
            foreach (var linePair in currentDialog.dialogLines) {
                var line = linePair.Key;
                var speaker = linePair.Value;
                bool flip = false;

                if (lastSpeaker == Speaker.None) {
                    if (speaker == Speaker.Player) {
                        flip = true;
                    }
                } else if (lastSpeaker != speaker) {
                    flip = true;
                }
                lastSpeaker = speaker;
                yield return textBoxUI.DisplayText_Co(line, flip, timeInSecondsPerChar);
            }
            SceneManager.LoadScene(combatSceneIndex);
        }
    }
}