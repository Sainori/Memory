using UnityEngine;

namespace LightAndCameraSystem
{
    public class LightAndCameraSystem : MonoBehaviour, ILightAndCameraSystem
    {
        [SerializeField] private float aspectConst = 33.75f;
        [SerializeField] private float distanceBetweenFieldAndCamera;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Vector3 additionalRotation = new Vector3(0, -90, 0);

        [SerializeField] private Transform lightOnScene;

        public void Initiallize(Vector3 fieldCenter)
        {
            mainCamera.fieldOfView = aspectConst / mainCamera.aspect;
            cameraTransform.position = new Vector3(fieldCenter.x, fieldCenter.y + distanceBetweenFieldAndCamera, fieldCenter.z);
            var toFieldDirection = (fieldCenter - cameraTransform.position).normalized;

            cameraTransform.rotation = Quaternion.Euler(Quaternion.LookRotation(toFieldDirection).eulerAngles + additionalRotation);
            lightOnScene.rotation = Quaternion.LookRotation(toFieldDirection);
        }
    }
}