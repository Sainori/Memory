using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoundSceneManager
{
    public class RoundSceneManager : MonoBehaviour, IRoundSceneManager
    {
        [SerializeField] private SceneAsset roundScene;
        
        public void OpenRoundScene()
        {
            SceneManager.LoadScene(roundScene.name, LoadSceneMode.Additive);
        }

        public void CloseRoundScene()
        {
            SceneManager.UnloadSceneAsync(roundScene.name);
        }
    }
}