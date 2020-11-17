using System.Collections;
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

        public IEnumerator OpenRoundScene()
        {
            if (_roundScene != default)
            {
                yield break;
            }

            yield return LoadAndInitRoundScene();
        }

        private IEnumerator LoadAndInitRoundScene()
        {
            SceneManager.LoadScene(roundSceneAsset.name, LoadSceneMode.Additive);
            _roundScene = SceneManager.GetSceneByName(roundSceneAsset.name);
            if (!_roundScene.isLoaded)
            {
                yield return null;
            }

            var rootRoundSceneObject = _roundScene.GetRootGameObjects().FirstOrDefault();
            if (rootRoundSceneObject == null)
            {
                Debug.LogError("Can't find root gameObject in RoundScene");
                yield break;
            }

            var roundManager = rootRoundSceneObject.GetComponent<IRoundManager>();
            if (roundManager == null)
            {
                Debug.LogError("Can't find IRoundManager component on root gameObject in RoundScene");
                yield break;
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