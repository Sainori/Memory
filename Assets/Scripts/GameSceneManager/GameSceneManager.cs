using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSceneManager
{
    public class GameSceneManager : MonoBehaviour, IGameSceneManager
    {
        public IEnumerator ChangeSceneOn(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);

            var scene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
            while (!scene.isLoaded)
            {
                yield return null;
            }

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public enum GameScenes
    {
        MenuScene = 0,
        RoundScene = 1
    }
}