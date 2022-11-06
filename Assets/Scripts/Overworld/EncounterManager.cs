using System;
using System.Collections;
using Dummerhuan.Combat;
using Dummerhuan.References;
using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;
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
        [SerializeField] private SpriteRenderer corpseRenderer;

        [SerializeField] private Sprite[] corpseSprites;
        
        private Speaker lastSpeaker = Speaker.None;

        protected void Awake() {
            Setup();
        }

        protected void Update() {
            var keyboard = Keyboard.current;
        }

        private void Setup() {
            int corpseCount = 0;
            if (paladin.defeated.Value == false) {
                currentEnemy.Value = paladin;
                aasimar.defeated.Value = false;
                elf.defeated.Value = false;
            } else if(aasimar.defeated.Value == false) {
                currentEnemy.Value = aasimar;
                elf.defeated.Value = false;
                paladin.defeated.Value = true;
                corpseCount = 1;
            } else if (elf.defeated.Value == false) {
                currentEnemy.Value = elf;
                aasimar.defeated.Value = true;
                paladin.defeated.Value = true;
                corpseCount = 2;
            } else {
                ResetGameState();
                return;
            }
            
            Debug.LogError( (paladin.defeated.Value.ToString() + aasimar.defeated.Value.ToString() + elf.defeated.Value.ToString()));
            SetupScene(currentEnemy.Value, corpseCount);
        }

        private void ResetGameState() {
            paladin.defeated.Value = false;
            aasimar.defeated.Value = false;
            elf.defeated.Value = false;
            Setup();
        }

        private void SetupScene(EnemySO enemy, int corpseCount) {
            playerRenderer.sprite = enemy.playerChibiSprite;
            playerRenderer.flipX = true;
            enemyRenderer.sprite = enemy.chibiSprite;

            if (corpseCount == 0) {
                corpseRenderer.sprite = null;
            } else {
                corpseRenderer.sprite = corpseSprites[corpseCount - 1];
            }
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