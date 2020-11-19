using RoundSystems.Interfaces;

namespace RoundSystems
{
    public class LivesSystem : ILivesSystem
    {
        public uint Lives { get; private set; }

        public LivesSystem(uint startLivesCount = 5)
        {
            Lives = startLivesCount;
        }

        public void RemoveLife()
        {
            Lives--;
        }
    }
}