using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan.Combat {
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemy", order = 0)]
    public class EnemySO : ScriptableObject {
        public Sprite portrait;
        public SerializableKeyValuePairs<InsultType, InsultSO[]> possibleInsults = 
            new();

        public GameObject miniGamePrefab;

    }
}