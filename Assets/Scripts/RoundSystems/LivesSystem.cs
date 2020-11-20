using System;
using RoundSystems.Interfaces;

namespace RoundSystems
{
    public class LivesSystem : ILivesSystem
    {
        public event Action OnLifeRemove = () => { };
        public event Action OnDeath = () => { };

        public uint MaxLives { get; }
        public uint Lives { get; private set; }

        public LivesSystem(uint maxLives = 5)
        {
            Lives = maxLives;
            MaxLives = maxLives;
        }

        public void RemoveLife()
        {
            Lives--;
            OnLifeRemove();

            if (Lives != 0)
            {
                return;
            }

            Death();
        }

        private void Death()
        {
            OnDeath();
        }
    }
}