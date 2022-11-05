using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan {
    [CreateAssetMenu(menuName = "ScriptableObjects/Insult", order = 0)]
    public class InsultSO : ScriptableObject {
        public string Insult;
        public string Response;
    }
}