using System;
using System.Collections;

namespace GameSceneManager
{
    public interface IGameSceneManager
    {
        event Action OnRoundOpen;
        event Action OnRoundClose;

        IEnumerator OpenRoundScene();
        void CloseRoundScene();
        void DirectUpdate();
    }
}