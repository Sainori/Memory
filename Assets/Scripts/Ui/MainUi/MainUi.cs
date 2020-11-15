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

        public void Initialize(ISaveManager saveManager, Action onPlayButtonClick)
        {
            _saveManager = saveManager;
            OnPlayButtonClick += onPlayButtonClick;
            playButton.onClick.AddListener(() => { OnPlayButtonClick(); });

            Activate();
            UpdateScoreText();
        }

        private void SetElementsState(bool isActive)
        {
            playButton.gameObject.SetActive(isActive);
            scoreText.gameObject.SetActive(isActive);
        }

        public void Activate()
        {
            SetElementsState(true);
        }

        public void Deactivate()
        {
            SetElementsState(false);
        }

        private void OnEnable()
        {
            if (_saveManager == null)
            {
                return;
            }

            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            scoreText.text = _saveManager.MaxScore.ToString();
        }
    }
}