using System;
using SaveManager;

namespace Ui.RoundUi
{
    public interface IRoundUi
    {
        void Initialize(ISaveManager saveManager, Action onBackButton);
    }
}