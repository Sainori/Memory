using System;
using RoundSystems.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.RoundUi
{
    public class RoundUi : MonoBehaviour, IRoundUi
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Text scoreText;

        private IScoreSystem _scoreSystem;

        public void Initialize(IScoreSystem scoreSystem, Action onBackButton)
        {
            _scoreSystem = scoreSystem;
            backButton.onClick.AddListener(() => onBackButton());

            UpdateScoreText();
            _scoreSystem.OnScoreUpdate += UpdateScoreText;
        }

        private void UpdateScoreText()
        {
            scoreText.text = _scoreSystem.Points.ToString();
        }
    }
}
