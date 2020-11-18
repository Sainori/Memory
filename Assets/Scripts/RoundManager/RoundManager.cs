using System;
using Ui.RoundUiManager;
using UnityEngine;
using GameSceneManager;
using PlayField;

namespace RoundManager
{
    public class RoundManager : MonoBehaviour, IRoundManager
    {
        private IRoundUiManager _roundUiManager;
        private IPlayField _playField;

        public void Initialize(IGameSceneManager gameSceneManager)
        {
            _roundUiManager = GetComponent<IRoundUiManager>();
            _playField = GetComponent<IPlayField>();

            _roundUiManager.Initialize(gameSceneManager);
            _playField.Initialize();
        }

        public void DirectUpdate()
        {
            
        }
    }
}