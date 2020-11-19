using System;

namespace RoundSystems.Interfaces
{
    public interface ILivesSystem
    {
        event Action OnDeath;

        uint Lives { get; }
        void RemoveLife();
    }
}