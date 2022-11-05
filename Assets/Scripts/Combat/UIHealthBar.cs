using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dummerhuan.Combat {
    public class UIHealthBar : MonoBehaviour {
        [SerializeField] private FloatReference maxHealth;
        [SerializeField] private FloatReference currentHealth;
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI healthTextMesh;
        
        protected void OnEnable() {
            OnHealthChanged();
        }

        public void OnHealthChanged() {
            if (currentHealth == null || maxHealth == null) {
                return;
            }

            fillImage.fillAmount = currentHealth.Value / maxHealth.Value;
            healthTextMesh.text = (int) currentHealth.Value + " / " + (int) maxHealth.Value;
        }
    }
}