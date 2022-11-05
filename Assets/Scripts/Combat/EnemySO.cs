using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan.Combat {
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemy", order = 0)]
    public class EnemySO : ScriptableObject {
        public SerializableKeyValuePairs<InsultType, InsultSO[]> possibleInsults = 
            new();

        [Separator]
        public SerializableKeyValuePairs<InsultType, Effectiveness> effectivenesses;
        [Separator]
        public GameObject miniGamePrefab;

        [Separator] 
        public Sprite idleSprite;
        public Sprite[] reactionSprites;

    }
}