using System;
using RoundSystems.Interfaces;

namespace PlayField
{
    public interface IPlayField
    {
        event Action OnGameEnd;

        void Initialize(IMatchSystem matchSystem);
        void DirectUpdate();
        void Reset();
    }
}