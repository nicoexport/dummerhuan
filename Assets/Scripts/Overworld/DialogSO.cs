using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Dummerhuan.Overworld {
    [CreateAssetMenu(menuName = "ScriptableObject/Dialog", order = 0)]
    public class DialogSO : ScriptableObject {
        public DialogLine[] allDialogLines;
    }
}


public enum Speaker {
    Player, 
    Enemy,
    None
}