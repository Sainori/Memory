namespace SaveManager
{
    public interface ISaveManager
    {
        int MaxScore { get; }
        bool TrySaveNewMax(int score);
    }
}