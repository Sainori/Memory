namespace SaveManager
{
    public interface ISaveManager
    {
        uint MaxScore { get; }
        void LoadSavedInfo();
        bool TrySaveNewMax(uint score);
    }
}