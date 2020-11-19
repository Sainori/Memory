using System;
using RoundSystems.Interfaces;

namespace RoundSystems
{
    public class LivesSystem : ILivesSystem
    {
        public event Action OnDeath = () => { };

        public uint Lives { get; private set; }

        public LivesSystem(uint startLivesCount = 5)
        {
            Lives = startLivesCount;
        }

        public void RemoveLife()
        {
            Lives--;

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