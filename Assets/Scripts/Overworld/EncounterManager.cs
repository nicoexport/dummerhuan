using System;
using System.Collections;
using Dummerhuan.Combat;
using Dummerhuan.References;
using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dummerhuan.Overworld {
    public class EncounterManager : MonoBehaviour {
        [SerializeField] private DialogSO currentDialog;
        [SerializeField] private FlippableTextBoxUI textBoxUI;
        [SerializeField] private float timeInSecondsPerChar = 0.08f;
        [SerializeField] private int combatSceneIndex = 1;

        [Separator]
        [Header("Game State")]
        [SerializeField] private EnemySOReference currentEnemy;

        [Separator] [Header("Enemies")] 
        [SerializeField] private EnemySO paladin;
        [SerializeField] private EnemySO aasimar;
        [SerializeField] private EnemySO elf;

        [Separator]
        [SerializeField] private SpriteRenderer playerRenderer;
        [SerializeField] private SpriteRenderer enemyRenderer;
        
        private Speaker lastSpeaker = Speaker.None;

        protected void Awake() {
            SetupScene();
        }

        private void SetupScene() {
            if (paladin.defeated.Value == false) {
                Debug.Log("setup paladin");
                currentEnemy.Value = paladin;
            } else if(aasimar.defeated.Value == false) {
                currentEnemy.Value = aasimar;
            }
            
            
            SetupScene(currentEnemy.Value);
            
        }

        private void SetupScene(EnemySO enemy) {
            playerRenderer.sprite = enemy.playerChibiSprite;
            playerRenderer.flipX = true;
            enemyRenderer.sprite = enemy.chibiSprite;

            currentDialog = enemy.overWorldDialog;
        }
        
        public void StartDialog() {
            StartCoroutine(DisplayDialog_Co());
        }
        
        private IEnumerator DisplayDialog_Co() {
            foreach (var linePair in currentDialog.allDialogLines) {
                var line = linePair.message;
                var speaker = linePair.speaker;
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

[Serializable]
public struct DialogLine {
    public string message;
    public Speaker speaker;
}