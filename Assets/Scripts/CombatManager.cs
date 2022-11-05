using Dummerhuan.References;
using MyBox;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Dummerhuan {
    public class CombatManager : Singleton<CombatManager> {
        [SerializeField] private EnemySOReference currentEnemy;

        protected void Awake() {
         
        }

        public void TestInsultButton(InsultType type) {
            var insults = currentEnemy.Value.possibleInsults[type];
            int rand = Random.Range(0, insults.Length);
            string insultText = insults[rand].Insult;
            Debug.Log(insultText);
        }
    }
}