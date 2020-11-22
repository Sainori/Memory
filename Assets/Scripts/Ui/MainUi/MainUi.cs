using System;
using SaveManager;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.MainUi
{
    public class MainUi : MonoBehaviour, IMainUi
    {
        [SerializeField] private string maxScoreMsg = "Лучший результат: {0}";

        [SerializeField] private Button playButton;
        [SerializeField] private Text scoreText;

        private ISaveManager _saveManager;

        public event Action OnPlayButtonClick = () => { };

        public void Initialize(ISaveManager saveManager)
        {
            _saveManager = saveManager;

            playButton.onClick.AddListener(() => OnPlayButtonClick());
            Activate();
        }

        private void Activate()
        {
            UpdateScoreText();

            playButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);

        }

        private void UpdateScoreText()
        {
            if (_saveManager == null)
            {
                return;
            }

            scoreText.text = string.Format(maxScoreMsg, _saveManager.MaxScore);
        }
    }
}