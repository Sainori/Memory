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

        public void Initialize(ISaveManager saveManager, IGameSceneManager gameSceneManager)
        {
            _saveManager = saveManager;

            var uiGameObject = Instantiate(uiPrefab, mainUiCanvas.transform);
            _mainUi = uiGameObject.GetComponent<IMainUi>();

            _mainUi.OnPlayButtonClick +=
                () => StartCoroutine(gameSceneManager.ChangeSceneOn((int) GameScenes.RoundScene));
            _mainUi.Initialize(_saveManager);
        }
    }
}