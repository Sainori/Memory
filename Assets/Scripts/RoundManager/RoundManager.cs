using System.Collections;
using Card;
using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;
using InputSystem;
using LightAndCameraSystem;
using PlayField;
using RoundSystems;
using RoundSystems.Interfaces;
using SaveManager;

namespace RoundManager
{
    public class RoundManager : MonoBehaviour
    {
        private ILivesSystem _livesSystem;
        private IScoreSystem _scoreSystem;
        private IMatchSystem _matchSystem;

        private IPlayField _playField;
        private ISaveManager _saveManager;
        private IInputSystem _inputSystem;
        private IRoundUiManager _roundUiManager;
        private IGameSceneManager _gameSceneManager;
        private bool isGameEnded;

        private Mesh[] _cardMeshes;
        private ILightAndCameraSystem _lightAndCameraSystem;

        private void Awake()
        {
            _livesSystem = new LivesSystem();
            _scoreSystem = new ScoreSystem();
            _matchSystem = new MatchSystem(_livesSystem, _scoreSystem);

            _playField = GetComponent<IPlayField>();
            _saveManager = GetComponent<ISaveManager>();
            _inputSystem = GetComponent<IInputSystem>();
            _roundUiManager = GetComponent<IRoundUiManager>();
            _gameSceneManager = GetComponent<IGameSceneManager>();
            _lightAndCameraSystem = GetComponent<ILightAndCameraSystem>();
            _cardMeshes = GetComponent<CardReferences>().GetCardObjects();

            StartCoroutine(InitializeRound());
        }

        private IEnumerator InitializeRound()
        {
            isGameEnded = true;

            _roundUiManager.Initialize(_scoreSystem, _livesSystem, _gameSceneManager, Restart);
            _saveManager.LoadSavedInfo();

            _livesSystem.OnDeath += () => OnGameEnd(false);
            _playField.OnGameEnd += () => OnGameEnd(true);

            yield return _playField.Initialize(_matchSystem, _cardMeshes, _lightAndCameraSystem);
            isGameEnded = false;
        }

        private void OnGameEnd(bool isWin)
        {
            isGameEnded = true;

            var isNewRecord = _saveManager.TrySaveNewMax(_scoreSystem.Points);
            _roundUiManager.ShowEndWindow(_scoreSystem.Points, _saveManager.MaxScore, isNewRecord, isWin);
        }

        private void Update()
        {
            if (isGameEnded)
            {
                return;
            }

            _inputSystem.DirectUpdate();
        }

        private void FixedUpdate()
        {
            _playField.DirectUpdate();
        }

        private IEnumerator Restart()
        {
            _livesSystem.Reset();
            _scoreSystem.Reset();
            _matchSystem.Reset();
            _roundUiManager.Reset();

            yield return _playField.Reset();

            isGameEnded = false;
        }
    }
}