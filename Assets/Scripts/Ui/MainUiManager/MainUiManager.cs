using System;
using SaveManager;
using Ui.MainUi;
using UnityEngine;

namespace Ui.MainUiManager
{
    public class MainUiManager : MonoBehaviour, IMainUiManager
    {
        [SerializeField] private Canvas mainUiCanvas;
        [SerializeField] private GameObject uiPrefab;

        private IMainUi _mainUi;
        private ISaveManager _saveManager;
        
        public void Initialize(ISaveManager saveManager, Action onPlayButtonClick)
        {
            _saveManager = saveManager;

            var uiGameObject = Instantiate(uiPrefab, mainUiCanvas.transform);
            _mainUi = uiGameObject.GetComponent<IMainUi>();

            onPlayButtonClick += _mainUi.Deactivate;
            _mainUi.Initialize(_saveManager, onPlayButtonClick);
        }
    }
}