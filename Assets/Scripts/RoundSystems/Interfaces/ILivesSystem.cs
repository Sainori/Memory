namespace RoundSystems.Interfaces
{
    public interface ILivesSystem
    {
        uint Lives { get; }
        void RemoveLife();
    }
}