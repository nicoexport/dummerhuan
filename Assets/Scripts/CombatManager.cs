using Dummerhuan.References;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Dummerhuan {
    public class CombatManager : MonoBehaviour {
        [SerializeField] private EnemySOReference currentEnemy;
        [SerializeField] private Image enemyPortrait;

        protected void Awake() {
            SetEnemySprite();
        }

        public void SetEnemySprite() => enemyPortrait.sprite = currentEnemy.Value.portrait;
    }
}