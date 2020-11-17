using System.Collections;

namespace GameSceneManager
{
    public interface IGameSceneManager
    {
        IEnumerator OpenRoundScene();
        void CloseRoundScene();
        void DirectUpdate();
    }
}