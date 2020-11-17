using GameSceneManager;
using SaveManager;

namespace Ui.MainUiManager
{
    public interface IMainUiManager
    {
        void Initialize(ISaveManager saveManager, IGameSceneManager gameSceneManager);
        void Activate();
        void Deactivate();
    }
}