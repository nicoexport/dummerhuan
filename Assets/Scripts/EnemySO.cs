using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan {
    [CreateAssetMenu(menuName = "Scriptable Objects/Enemy", order = 0)]
    public class EnemySO : ScriptableObject {
        public FloatReference currentHealth;
        public FloatReference maxHealth;
        public Sprite portrait;
    }
}