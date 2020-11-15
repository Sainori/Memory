using System;
using SaveManager;

namespace Ui.MainUiManager
{
    public interface IMainUiManager
    {
        void Initialize(ISaveManager saveManager, Action onPlayButtonClick);
    }
}