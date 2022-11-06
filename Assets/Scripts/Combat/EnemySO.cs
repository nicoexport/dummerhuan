using Dummerhuan.Audio;
using Dummerhuan.Overworld;
using MyBox;
using ScriptableObjectArchitecture;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan.Combat {
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemy", order = 0)]
    public class EnemySO : ScriptableObject {

        public BoolReference defeated;
        
        [Separator]
        public SerializableKeyValuePairs<InsultType, InsultSO[]> possibleInsults = 
            new();

        [Separator]
        public SerializableKeyValuePairs<InsultType, Effectiveness> effectivenesses;
        [Separator]
        public GameObject[] miniGamePrefabs;

        [Separator] 
        [Header("Combat")]
        public Sprite idleSprite;
        public Sprite[] reactionSprites;
        [Header("Overworld")]
        public Sprite chibiSprite;
        public Sprite playerChibiSprite;
        public Sprite chibiHeadSprite;

        [Separator] 
        public DialogSO overWorldDialog;
        
        [Separator] 
        public AudioConfigSo speakerConfig;

        public GameObject GetMiniGamePrefab() {
            int rand = Random.Range(0, miniGamePrefabs.Length);
            return miniGamePrefabs[rand];
        }

    }
}