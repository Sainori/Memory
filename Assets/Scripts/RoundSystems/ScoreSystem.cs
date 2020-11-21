using System;
using RoundSystems.Interfaces;

namespace RoundSystems
{
    public class ScoreSystem : IScoreSystem
    {
        public event Action OnScoreUpdate = () => { };
        public uint Points { get; private set; }

        public void AddPoints(uint points)
        {
            Points += points;
            OnScoreUpdate();
        }

        public void Reset()
        {
            Points = 0;
        }
    }
}