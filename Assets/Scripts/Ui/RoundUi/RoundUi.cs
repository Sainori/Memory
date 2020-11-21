using System;
using System.Security.Cryptography;
using RoundSystems.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.RoundUi
{
    public class RoundUi : MonoBehaviour, IRoundUi
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Text scoreText;

        [SerializeField] private Transform livesContainer;
        [SerializeField] private Life lifeSample;

        private Life[] _lives;

        private IScoreSystem _scoreSystem;
        private ILivesSystem _livesSystem;

        public void Initialize(IScoreSystem scoreSystem, ILivesSystem livesSystem, Action onBackButton)
        {
            _scoreSystem = scoreSystem;
            _livesSystem = livesSystem;

            UpdateScoreText();
            SetupLives();

            _scoreSystem.OnScoreUpdate += UpdateScoreText;
            _livesSystem.OnLifeRemove += RemoveLife;
            backButton.onClick.AddListener(() => onBackButton());
        }

        public void Reset()
        {
            foreach (var life in _lives)
            {
                Destroy(life.gameObject);
            }

            UpdateScoreText();
            SetupLives();
        }

        private void SetupLives()
        {
            _lives = new Life[_livesSystem.MaxLives];

            for (var i = 0; i < _livesSystem.Lives; i++)
            {
                var life = Instantiate(lifeSample, livesContainer);
                life.gameObject.SetActive(true);
                life.ActivateLife();
                _lives[i] = life;
            }
        }

        private void UpdateScoreText()
        {
            scoreText.text = _scoreSystem.Points.ToString();
        }

        private void RemoveLife()
        {
            _lives[_livesSystem.Lives].DeactivateLife();
        }

        private void OnDestroy()
        {
            _scoreSystem.OnScoreUpdate -= UpdateScoreText;
            _livesSystem.OnLifeRemove -= RemoveLife;
        }
    }
}
