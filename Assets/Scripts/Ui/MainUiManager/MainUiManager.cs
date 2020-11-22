using GameSceneManager;
using SaveManager;
using Ui.MainUi;
using UnityEngine;

namespace Ui.MainUiManager
{
    public class MainUiManager : MonoBehaviour, IMainUiManager
    {
        [SerializeField] private Canvas mainUiCanvas;
        [SerializeField] private GameObject uiPrefab;

        private IMainUi _mainUi;
        private ISaveManager _saveManager;
        private IGameSceneManager _gameSceneManager;

        public void Initialize(ISaveManager saveManager, IGameSceneManager gameSceneManager)
        {
            _saveManager = saveManager;
            _gameSceneManager = gameSceneManager;

            ShowPlayButton();
        }

        private void ShowPlayButton()
        {
            var uiGameObject = Instantiate(uiPrefab, mainUiCanvas.transform);
            _mainUi = uiGameObject.GetComponent<IMainUi>();
            _mainUi.OnPlayButtonClick += OnPlay;
            _mainUi.Initialize(_saveManager);
        }

        private void OnPlay()
        {
            _mainUi.OnPlayButtonClick -= OnPlay;
            StartCoroutine(_gameSceneManager.ChangeSceneOn((int) GameScenes.RoundScene));
        }
    }
}