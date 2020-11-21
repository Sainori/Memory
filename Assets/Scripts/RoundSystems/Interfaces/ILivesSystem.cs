using System;

namespace RoundSystems.Interfaces
{
    public interface ILivesSystem
    {
        event Action OnLifeRemove;
        event Action OnDeath;

        uint MaxLives { get; }
        uint Lives { get; }
        void RemoveLife();
        void Reset();
    }
}