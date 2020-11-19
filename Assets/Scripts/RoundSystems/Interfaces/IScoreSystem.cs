namespace RoundSystems.Interfaces
{
    public interface IScoreSystem
    {
        uint Points { get; }
        void AddPoints(uint points);
    }
}