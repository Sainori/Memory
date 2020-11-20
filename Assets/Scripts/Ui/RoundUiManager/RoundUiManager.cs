using GameSceneManager;
using RoundSystems.Interfaces;
using Ui.RoundUi;
using UnityEngine;

namespace Ui.RoundUiManager
{
    public class RoundUiManager : MonoBehaviour, IRoundUiManager
    {
        [SerializeField] private GameObject roundUi;
        [SerializeField] private Canvas roundUiCanvas;
        private IRoundUi _roundUi;
        private IGameSceneManager _gameSceneManager;

        public void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, IGameSceneManager gameSceneManager)
        {
            _gameSceneManager = gameSceneManager;
            var uiGameObject = Instantiate(roundUi, roundUiCanvas.transform);
            _roundUi = uiGameObject.GetComponent<IRoundUi>();
            _roundUi.Initialize(scoreSystem, livesSystem, OnBackButton);
        }

        private void OnBackButton()
        {
            StartCoroutine(_gameSceneManager.ChangeSceneOn((int) GameScenes.MenuScene));
        }
    }
}