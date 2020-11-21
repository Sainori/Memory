using System;
using GameSceneManager;
using RoundSystems.Interfaces;

namespace Ui.RoundUiManager
{
    public interface IRoundUiManager
    {
        void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, IGameSceneManager gameSceneManager, Action onRestart);
        void ShowEndWindow(uint score, uint maxScore, bool isNewRecord, bool isWin);
        void Reset();
    }
}