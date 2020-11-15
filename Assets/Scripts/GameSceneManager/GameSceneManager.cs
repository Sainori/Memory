using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSceneManager
{
    public class GameSceneManager : MonoBehaviour, IGameSceneManager
    {
        [SerializeField] private SceneAsset roundSceneAsset;

        public void OpenRoundScene()
        {
            SceneManager.LoadScene(roundSceneAsset.name, LoadSceneMode.Additive);
        }

        public void CloseRoundScene()
        {
            SceneManager.UnloadSceneAsync(roundSceneAsset.name);
        }

        public void DirectUpdate()
        {
            
        }
    }
}