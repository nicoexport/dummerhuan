using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan {
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemy", order = 0)]
    public class EnemySO : ScriptableObject {
        public Sprite portrait;
        public SerializableKeyValuePairs<InsultType, InsultSO[]> possibleInsults = 
            new();
    }
}