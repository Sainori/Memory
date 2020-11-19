using RoundSystems.Interfaces;

namespace PlayField
{
    public interface IPlayField
    {
        void Initialize(IMatchSystem matchSystem);
    }
}