using GameSceneManager;
using Ui.RoundUi;
using UnityEngine;

namespace Ui.RoundUiManager
{
    public class RoundUiManager : MonoBehaviour, IRoundUiManager
    {
        [SerializeField] private GameObject roundUi;
        [SerializeField] private Canvas roundUiCanvas;
        private IRoundUi _roundUi;

        public void Initialize(IGameSceneManager gameSceneManager)
        {
            var uiGameObject = Instantiate(roundUi, roundUiCanvas.transform);
            _roundUi = uiGameObject.GetComponent<IRoundUi>();

            _roundUi.Initialize(null, gameSceneManager.CloseRoundScene );
        }
    }
}