using GameSceneManager;

namespace RoundManager
{
    public interface IRoundManager
    {
        void Initialize(IGameSceneManager gameSceneManager);
        void DirectUpdate();
    }
}