using System.Collections;

namespace Dummerhuan.MiniGames {
    public interface IMiniGame {
        abstract IEnumerator Execute();
        abstract void End();
    }
}