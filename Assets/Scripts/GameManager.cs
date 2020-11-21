using GameSceneManager;
using SaveManager;
using Ui.MainUiManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ISaveManager _saveManager;
    private IMainUiManager _uiManager;
    private IGameSceneManager _gameSceneManager;

    private void Awake()
    {
        _uiManager = GetComponent<IMainUiManager>();
        _saveManager = GetComponent<ISaveManager>();
        _gameSceneManager = GetComponent<IGameSceneManager>();

        _saveManager.LoadSavedInfo();
        _uiManager.Initialize(_saveManager, _gameSceneManager);
    }
}
