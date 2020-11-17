using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;

namespace RoundManager
{
    public class RoundManager : MonoBehaviour, IRoundManager
    {
        private IRoundUiManager _roundUiManager;
        private IGameSceneManager _gameSceneManager;

        //TODO: add cleanup after scene is closed to prevent bugs
        public void Initialize(IGameSceneManager gameSceneManager)
        {
            _gameSceneManager = gameSceneManager;
            _roundUiManager = GetComponent<RoundUiManager>();
            _roundUiManager.Initialize(gameSceneManager);
        }

        public void DirectUpdate()
        {
        }
    }
}