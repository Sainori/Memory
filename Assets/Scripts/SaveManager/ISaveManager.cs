namespace SaveManager
{
    public interface ISaveManager
    {
        uint MaxScore { get; }
        bool TrySaveNewMax(uint score);
    }
}