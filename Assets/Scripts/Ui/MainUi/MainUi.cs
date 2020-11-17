using System;
using SaveManager;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.MainUi
{
    public class MainUi : MonoBehaviour, IMainUi
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Text scoreText;

        private ISaveManager _saveManager;

        public event Action OnPlayButtonClick = () => { };

        public void Initialize(ISaveManager saveManager)
        {
            _saveManager = saveManager;
            playButton.onClick.AddListener(() => { OnPlayButtonClick(); });

            Activate();
        }

        private void SetElementsState(bool isActive)
        {
            playButton.gameObject.SetActive(isActive);
            scoreText.gameObject.SetActive(isActive);
        }

        public void Activate()
        {
            UpdateScoreText();
            SetElementsState(true);
        }

        public void Deactivate()
        {
            SetElementsState(false);
        }

        private void UpdateScoreText()
        {
            if (_saveManager == null)
            {
                return;
            }

            scoreText.text = _saveManager.MaxScore.ToString();
        }
    }
}