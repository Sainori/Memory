using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;
using InputSystem;
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

        public void Awake()
        {
            _livesSystem = new LivesSystem();
            _scoreSystem = new ScoreSystem();

            _matchSystem = new MatchSystem(_livesSystem, _scoreSystem);

            _playField = GetComponent<IPlayField>();
            _saveManager = GetComponent<ISaveManager>();
            _inputSystem = GetComponent<IInputSystem>();
            _roundUiManager = GetComponent<IRoundUiManager>();
            _gameSceneManager = GetComponent<IGameSceneManager>();

            _playField.Initialize(_matchSystem);
            _roundUiManager.Initialize(_scoreSystem, _livesSystem, _gameSceneManager);
            _saveManager.LoadSavedInfo();

            _livesSystem.OnDeath += () => OnGameEnd(false);
            _playField.OnGameEnd += () => OnGameEnd(true);

            isGameEnded = false;
        }

        private void OnGameEnd(bool isWin)
        {
            isGameEnded = true;

            var isNewRecord = _saveManager.TrySaveNewMax(_scoreSystem.Points);
            _roundUiManager.ShowEndWindow(_scoreSystem.Points, _saveManager.MaxScore, isNewRecord, isWin);
        }

        public void Update()
        {
            if (isGameEnded)
            {
                return;
            }

            _inputSystem.DirectUpdate();
        }

        public void FixedUpdate()
        {
            _playField.DirectUpdate();
        }
    }
}