using System;
using SaveManager;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.MainUi
{
    public class MainUi : MonoBehaviour, IMainUi
    {
        [SerializeField] private string maxScoreMsg = "Лучший результат: {0}";

        [SerializeField] private float playButtonWidthScreenPercent = 0.6f;
        [SerializeField] private float playButtonHeightPercent = 0.3f;

        [SerializeField] private float scoreTextWidthScreenPercent = 0.9f;
        [SerializeField] private float scoreTextHeightPercent = 0.2f;

        [SerializeField] private Button playButton;
        [SerializeField] private Text scoreText;

        private ISaveManager _saveManager;

        public event Action OnPlayButtonClick = () => { };

        public void Initialize(ISaveManager saveManager)
        {
            _saveManager = saveManager;

            SetupPlayButton();
            SetObjectRect(scoreText, scoreTextWidthScreenPercent, scoreTextHeightPercent);
            Activate();
        }

        private void SetupPlayButton()
        {
            playButton.onClick.AddListener(() => OnPlayButtonClick());
            SetObjectRect(playButton, playButtonWidthScreenPercent, playButtonHeightPercent);
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

        private void SetObjectRect(MonoBehaviour monoObject, float widthToScreenPercent, float heightToWidthPercent)
        {
            var rectTransform = monoObject.GetComponent<RectTransform>();
            if (rectTransform == null)
            {
                return;
            }

            var width = Screen.width * widthToScreenPercent;
            rectTransform.sizeDelta = new Vector2(width, width * heightToWidthPercent);
        }
    }
}