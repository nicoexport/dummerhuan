using System;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Dummerhuan {
    public class UIHealth : MonoBehaviour {
        [SerializeField] private IntReference maxHealth;
        [SerializeField] private IntReference currentHealth;
        [SerializeField] private TextMeshProUGUI healthText;

        protected void OnEnable() {
            OnHealthChanged();
        }

        public void OnHealthChanged() {
            healthText.text = currentHealth.Value.ToString();
        }
    }
}