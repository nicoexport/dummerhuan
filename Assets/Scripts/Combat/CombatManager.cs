using System;
using System.Collections;
using Dummerhuan.MiniGames;
using Dummerhuan.References;
using MyBox;
using ScriptableObjectArchitecture;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Dummerhuan.Combat {
    public class CombatManager : Singleton<CombatManager> {
        [SerializeField] private EnemySOReference currentEnemy;
        [SerializeField] private Vector3 miniGameSpawnOffset;
        [SerializeField] private FloatReference playerMaxHealth;
        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private TextBoxUI enemyTextBox;
        [SerializeField] private TextBoxUI playerTextBox;

        private InsultSO intendedInsult;
        private Coroutine combatCoroutine;
        private IMiniGame currentMiniGame;
        
        protected void Awake() {
            if (combatCoroutine != null) {
                StopCoroutine(combatCoroutine);
            }

            combatCoroutine = StartCoroutine(CombatLoop_Co());

            playerCurrentHealth.Value = playerMaxHealth.Value;
        }

        private IEnumerator CombatLoop_Co() {
            while (true) {
                yield return new WaitUntil(()=>intendedInsult);
                yield return playerTextBox.DisplayText_Co("You: " + intendedInsult.Insult, 1f);
                yield return enemyTextBox.DisplayText_Co("Enemy: ...", 0.5f);
                yield return enemyTextBox.DisplayText_Co("Enemy: " + intendedInsult.Response, 1.5f);
                
                var miniGamePrefab = currentEnemy.Value.miniGamePrefab;
                var miniGame = Instantiate(miniGamePrefab, transform.position + miniGameSpawnOffset, 
                    quaternion.identity);
                miniGame.TryGetComponent(out currentMiniGame);
                if (currentMiniGame != null) {
                    yield return currentMiniGame.Execute();
                }
                intendedInsult = null;
                currentMiniGame = null;
                if (playerCurrentHealth.Value <= 0) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                Debug.Log("Turn ended");
            }
        }

        public void TestInsultButton(InsultType type) {
            if (intendedInsult) {
                return;
            }
            var insults = currentEnemy.Value.possibleInsults[type];
            int rand = Random.Range(0, insults.Length);
            intendedInsult = insults[rand];
        }

        private IEnumerator TestMiniGame_Co() {
            yield return new WaitForSeconds(2f);
            Debug.Log("Minigame finished");
        }

        protected void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + miniGameSpawnOffset, 0.3f);
        }
    }
}