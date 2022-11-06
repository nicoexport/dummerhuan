using UnityEngine;

namespace Dummerhuan.Combat {
    [CreateAssetMenu(menuName = "ScriptableObjects/Insult", order = 0)]
    public class InsultSO : ScriptableObject {
        public string Insult;
        public string[] Responses;

        public string GetResponse() {
            if (Responses.Length == 0) {
                return "You suck!";
            }
            int rand = Random.Range(0, Responses.Length);
            return Responses[rand];
        }
    }
}