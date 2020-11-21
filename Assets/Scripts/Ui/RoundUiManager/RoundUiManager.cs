using System;
using GameSceneManager;
using RoundSystems.Interfaces;
using Ui.EndGameWindow;
using Ui.RoundUi;
using UnityEngine;

namespace Ui.RoundUiManager
{
    public class RoundUiManager : MonoBehaviour, IRoundUiManager
    {
        [SerializeField] private GameObject roundUiPrefab;
        [SerializeField] private GameObject endGamePrefab;

        [SerializeField] private Canvas roundUiCanvas;

        private IRoundUi _roundUi;
        private IEndGameWindow _endGameWindow;
        private IGameSceneManager _gameSceneManager;

        public void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, IGameSceneManager gameSceneManager, Action onRestart)
        {
            _gameSceneManager = gameSceneManager;

            var uiGameObject = Instantiate(roundUiPrefab, roundUiCanvas.transform);
            _roundUi = uiGameObject.GetComponent<IRoundUi>();
            _roundUi.Initialize(scoreSystem, livesSystem, OnBackButton);

            var endGameObject = Instantiate(endGamePrefab, roundUiCanvas.transform);
            _endGameWindow = endGameObject.GetComponent<IEndGameWindow>();
            _endGameWindow.Initialize();

            _endGameWindow.OnRestartButton += onRestart;
            _endGameWindow.OnBackButton += OnBackButton;
        }

        public void ShowEndWindow(uint score, uint maxScore, bool isNewRecord, bool isWin)
        {
            _endGameWindow.Show(score, maxScore, isNewRecord, isWin);
        }

        public void Reset()
        {
            _endGameWindow.Close();
            _roundUi.Reset();
        }

        private void OnBackButton()
        {
            StartCoroutine(_gameSceneManager.ChangeSceneOn((int) GameScenes.MenuScene));
        }
    }
}