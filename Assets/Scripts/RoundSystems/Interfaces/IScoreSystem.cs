using System;

namespace RoundSystems.Interfaces
{
    public interface IScoreSystem
    {
        event Action OnScoreUpdate;

        uint Points { get; }
        void AddPoints(uint points);
    }
}