using System;
using SaveManager;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.RoundUi
{
    public class RoundUi : MonoBehaviour, IRoundUi
    {
        [SerializeField] private Button _backButton;

        public void Initialize(ISaveManager saveManager, Action onBackButton)
        {
            _backButton.onClick.AddListener(() => onBackButton());
        }
    }
}