using System.Linq;
using RoundManager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSceneManager
{
    public class GameSceneManager : MonoBehaviour, IGameSceneManager
    {
        [SerializeField] private SceneAsset roundSceneAsset;
        private Scene _roundScene;
        private IRoundManager _roundManager;

        public void OpenRoundScene()
        {
            if (_roundScene != default)
            {
                return;
            }

            LoadAndInitRoundScene();
        }

        private void LoadAndInitRoundScene()
        {
            SceneManager.LoadScene(roundSceneAsset.name, LoadSceneMode.Additive);
            _roundScene = SceneManager.GetSceneByName(roundSceneAsset.name);

            var rootRoundSceneObject = _roundScene.GetRootGameObjects().FirstOrDefault();
            if (rootRoundSceneObject == null)
            {
                Debug.LogError("Can't find root gameObject in RoundScene");
                return;
            }

            var roundManager = rootRoundSceneObject.GetComponent<IRoundManager>();
            if (roundManager == null)
            {
                Debug.LogError("Can't find IRoundManager component on root gameObject in RoundScene");
                return;
            }

            _roundManager = roundManager;
        }

        public void CloseRoundScene()
        {
            SceneManager.UnloadSceneAsync(roundSceneAsset.name);
        }

        public void DirectUpdate()
        {
            _roundManager?.DirectUpdate();
        }
    }
}