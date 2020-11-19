using RoundSystems.Interfaces;
using UnityEngine;

namespace RoundSystems
{
    public class ScoreSystem : IScoreSystem
    {
        public uint Points { get; private set; }

        public void AddPoints(uint points)
        {
            Points += points;
            Debug.Log("POINTS " + Points);
        }
    }
}