using System;
using SaveManager;

namespace Ui.MainUi
{
    public interface IMainUi
    {
        event Action OnPlayButtonClick;
        void Initialize(ISaveManager saveManager);

        void Activate();
        void Deactivate();
    }
}