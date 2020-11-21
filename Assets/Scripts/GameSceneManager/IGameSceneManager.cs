using System.Collections;

namespace GameSceneManager
{
    public interface IGameSceneManager
    {
        IEnumerator ChangeSceneOn(int sceneBuildIndex);
    }
}