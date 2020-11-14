using RoundSceneManager;
using SaveManager;

namespace MainUiManager
{
    public interface IMainUiManager
    {
        void Initialize(ISaveManager saveManager, IRoundSceneManager roundSceneManager);
    }
}