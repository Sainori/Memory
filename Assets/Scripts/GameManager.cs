using GameSceneManager;
using InputSystem;
using SaveManager;
using Ui.MainUiManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ISaveManager _saveManager;
    private IMainUiManager _uiManager;
    private IInputSystem _inputSystem;
    private IGameSceneManager _gameSceneManager;

    private void Awake()
    {
        _uiManager = GetComponent<IMainUiManager>();
        _saveManager = GetComponent<ISaveManager>();
        _inputSystem = GetComponent<IInputSystem>();
        _gameSceneManager = GetComponent<IGameSceneManager>();

        _saveManager.LoadSavedInfo();
        _uiManager.Initialize(_saveManager, _gameSceneManager);

        _gameSceneManager.OnRoundOpen += _uiManager.Deactivate;
        _gameSceneManager.OnRoundClose += _uiManager.Activate;
    }

    private void Update()
    {
        _inputSystem.DirectUpdate();
    }

    private void OnDestroy()
    {
        _gameSceneManager.OnRoundOpen -= _uiManager.Deactivate;
        _gameSceneManager.OnRoundClose -= _uiManager.Activate;
    }
}
