using System;
using Dummerhuan.References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dummerhuan {
    public class CombatUI : MonoBehaviour {
        [SerializeField] private EnemySOReference currentEnemy;
        [SerializeField] private Image enemyPortrait;
        [SerializeField] private InsultButton[] buttons;

        protected void Awake() {
            SetEnemySprite();
            SetupButtons();
        }

        public void OnEnemyChanged() {
            SetEnemySprite();
        }

        private void SetEnemySprite() => enemyPortrait.sprite = currentEnemy.Value.portrait;

        private void SetupButtons() {
            for (int i = 0; i < buttons.Length; i++) {
                var type = (InsultType)i;
                buttons[i].Setup(type);
            }
        }
    }
}