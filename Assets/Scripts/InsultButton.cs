using TMPro;
using UnityEngine;

namespace Dummerhuan {
    public class InsultButton : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private InsultType insultType;

        protected void OnValidate() {
            if (!textMesh) {
                TryGetComponent(out textMesh);
            }
        }

        public void Setup(InsultType type) {
            insultType = type;
            textMesh.text = type.ToString();
        }

        public void OnClicked() {
            CombatManager.Instance.TestInsultButton(insultType);
        }
    }
}