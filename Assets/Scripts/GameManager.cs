using InputSystem;
using MainUiManager;
using RoundSceneManager;
using SaveManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ISaveManager _saveManager;
    private IMainUiManager _uiManager;
    private IInputSystem _inputSystem;
    private IRoundSceneManager _roundSceneManager;

    private void Awake()
    {
        _uiManager = GetComponent<IMainUiManager>();
        _saveManager = GetComponent<ISaveManager>();
        _inputSystem = GetComponent<IInputSystem>();
        _roundSceneManager = GetComponent<IRoundSceneManager>();

        MangerInitialization();
    }

    private void MangerInitialization()
    {
        _uiManager.Initialize(_saveManager, _roundSceneManager);
    }

    private void Update()
    {
        _inputSystem.DirectUpdate();
    }
}
