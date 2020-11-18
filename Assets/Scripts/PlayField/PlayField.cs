using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayField
{
    public class PlayField : MonoBehaviour, IPlayField
    {
        private const uint columnCount = 3;
        private const uint rowCount = 5;

        [SerializeField] private Vector3 upLeftCorner;
        [SerializeField] private float spaceBetween;

        [SerializeField] private GameObject cardPrefab;

        private List<GameObject> cardObjects = new List<GameObject>();

        public void Initialize()
        {
            for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    var cardTransform = new Vector3(upLeftCorner.x + spaceBetween * rowIndex, upLeftCorner.y,
                        upLeftCorner.z + spaceBetween * columnIndex);

                    cardObjects.Add(Instantiate(cardPrefab, cardTransform , Quaternion.identity, transform));
                }
            }

            SetCameraAboveFieldCenter(Camera.main.transform);
            StartCoroutine(SetupCameraTransform(Camera.main));
        }

        private IEnumerator SetupCameraTransform(Camera mainCamera)
        {
            var upLeftCard = cardObjects.First();
            var downRightCard = cardObjects.Last();

            bool isAllCardsVisible = false;
            while (!isAllCardsVisible)
            {
                var upLeftCameraPoint = mainCamera.WorldToViewportPoint(upLeftCard.transform.position - Vector3.one);
                var downRightCameraPoint = mainCamera.WorldToViewportPoint(downRightCard.transform.position + Vector3.one);

                if (upLeftCameraPoint.x < 0 || upLeftCameraPoint.y < 0 || downRightCameraPoint.x > 1 || downRightCameraPoint.y > 1 )
                {
                    mainCamera.transform.position = new Vector3(
                        mainCamera.transform.position.x,
                        mainCamera.transform.position.y + spaceBetween,
                        mainCamera.transform.position.z);

                    yield return null;
                    continue;
                }

                isAllCardsVisible = true;
            }
        }

        private void SetCameraAboveFieldCenter(Transform cameraTransform)
        {
            var cameraXPosition = (upLeftCorner.x + spaceBetween * (rowCount - 1)) / 2;
            var cameraZPosition = (upLeftCorner.z + spaceBetween * (columnCount - 1)) / 2;

            cameraTransform.position = new Vector3(cameraXPosition, cameraTransform.position.y, cameraZPosition);
        }
    }
}