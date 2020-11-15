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

        _uiManager.Initialize(_saveManager, () => { _gameSceneManager.OpenRoundScene(); });
    }

    private void Update()
    {
        _inputSystem.DirectUpdate();
    }

    private void FixedUpdate()
    {
        _gameSceneManager.DirectUpdate();
    }
}
