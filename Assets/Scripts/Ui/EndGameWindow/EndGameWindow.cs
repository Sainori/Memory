using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.EndGameWindow
{
    public class EndGameWindow : MonoBehaviour, IEndGameWindow
    {
        public event Action OnRestartButton = () => { };
        public event Action OnBackButton = () => { };

        [SerializeField] private string scoreMsg = "Ваш результат: {0}";
        [SerializeField] private string maxScoreMsg = "Лучший результат: {0}";

        [SerializeField] private string winMsg = "ВЫ ПОБЕДИЛИ!";
        [SerializeField] private string loseMsg = "ВЫ ПРОИГРАЛИ!";

        [SerializeField] private GameObject container;

        [SerializeField] private Text maxScoreText;
        [SerializeField] private Text scorePoints;
        [SerializeField] private Text resultLabel;

        [SerializeField] private GameObject newRecord;

        [SerializeField] private Button backButton;
        [SerializeField] private Button restartButton;

        public void Initialize()
        {
            backButton.onClick.AddListener( () => OnBackButton());
            restartButton.onClick.AddListener( () => OnRestartButton());
        }

        public void Show(uint score, uint maxScore, bool isNewMax, bool isWin)
        {
            container.SetActive(true);

            scorePoints.text = string.Format(scoreMsg, score);
            maxScoreText.text = string.Format(maxScoreMsg, maxScore);

            resultLabel.text = isWin ? winMsg : loseMsg;
            newRecord.SetActive(isNewMax);
        }

        public void Close()
        {
            container.SetActive(false);
        }
    }
}