using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;
using PlayField;
using RoundSystems;
using RoundSystems.Interfaces;

namespace RoundManager
{
    public class RoundManager : MonoBehaviour
    {
        private ILivesSystem _livesSystem;
        private IScoreSystem _scoreSystem;
        private IMatchSystem _matchSystem;

        private IPlayField _playField;
        private IRoundUiManager _roundUiManager;
        private IGameSceneManager _gameSceneManager;

        public void Awake()
        {
            _livesSystem = new LivesSystem();
            _scoreSystem = new ScoreSystem();

            _matchSystem = new MatchSystem(_livesSystem, _scoreSystem);

            _playField = GetComponent<IPlayField>();
            _roundUiManager = GetComponent<IRoundUiManager>();
            _gameSceneManager = GetComponent<IGameSceneManager>();

            _playField.Initialize(_matchSystem);
            _roundUiManager.Initialize(_scoreSystem, _livesSystem, _gameSceneManager);

            _livesSystem.OnDeath += OnGameEnd;
            _playField.OnGameEnd += OnGameEnd;
        }

        private void OnGameEnd()
        {
            Debug.Log("Game End");
            Debug.Log("Lives total " + _livesSystem.Lives);
            Debug.Log("Points total " + _scoreSystem.Points);

            // _roundUiManager.ShowEndWindow();
            //inputSystem.Deactivate();
        }

        public void FixedUpdate()
        {
            _playField.DirectUpdate();
        }
    }
}