using System;
using RoundSystems.Interfaces;

namespace Ui.RoundUi
{
    public interface IRoundUi
    {
        void Initialize(IScoreSystem scoreSystem, Action onBackButton);
    }
}