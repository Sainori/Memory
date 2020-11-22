using System;
using System.Collections;
using GameSceneManager;
using RoundSystems.Interfaces;

namespace Ui.RoundUiManager
{
    public interface IRoundUiManager
    {
        void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, IGameSceneManager gameSceneManager,
            Func<IEnumerator> onRestart);
        void ShowEndWindow(uint score, uint maxScore, bool isNewRecord, bool isWin);
        void Reset();
    }
}