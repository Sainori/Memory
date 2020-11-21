using System;

namespace Ui.EndGameWindow
{
    public interface IEndGameWindow
    {
        event Action OnRestartButton;
        event Action OnBackButton;

        void Initialize();
        void Show(uint score, uint maxScore, bool isNewMax, bool isWin);
        void Close();
    }
}