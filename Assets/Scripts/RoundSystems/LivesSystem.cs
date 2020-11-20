using System;
using RoundSystems.Interfaces;

namespace RoundSystems
{
    public class LivesSystem : ILivesSystem
    {
        public event Action OnLifeRemove = () => { };
        public event Action OnDeath = () => { };

        public uint Lives { get; private set; }

        public LivesSystem(uint startLivesCount = 5)
        {
            Lives = startLivesCount;
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