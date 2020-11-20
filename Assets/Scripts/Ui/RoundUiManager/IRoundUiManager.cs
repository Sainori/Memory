using GameSceneManager;
using RoundSystems.Interfaces;

namespace Ui.RoundUiManager
{
    public interface IRoundUiManager
    {
        void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, IGameSceneManager gameSceneManager);
    }
}