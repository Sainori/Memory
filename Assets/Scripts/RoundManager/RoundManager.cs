using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;
using PlayField;
using RoundSystems;
using RoundSystems.Interfaces;

namespace RoundManager
{
    public class RoundManager : MonoBehaviour, IRoundManager
    {
        private ILivesSystem _livesSystem;
        private IScoreSystem _scoreSystem;
        private IMatchSystem _matchSystem;

        private IPlayField _playField;
        private IRoundUiManager _roundUiManager;

        public void Initialize(IGameSceneManager gameSceneManager)
        {
            _livesSystem = new LivesSystem();
            _scoreSystem = new ScoreSystem();

            _matchSystem = new MatchSystem(_livesSystem, _scoreSystem);

            _roundUiManager = GetComponent<IRoundUiManager>();
            _playField = GetComponent<IPlayField>();

            _roundUiManager.Initialize(gameSceneManager);
            _playField.Initialize(_matchSystem);
        }

        public void DirectUpdate()
        {
            
        }
    }
}