using System.Collections;
using Dummerhuan.Combat;
using UnityEngine;

namespace Dummerhuan.MiniGames {
    public interface IMiniGame {
        abstract void Setup(Effectiveness effectiveness);
        abstract IEnumerator Execute();
        abstract void End();
    } 
}