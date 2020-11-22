using UnityEngine;

namespace LightAndCameraSystem
{
    public class LightAndCameraSystem : MonoBehaviour, ILightAndCameraSystem
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private float distanceBetweenFieldAndCamera;
        [SerializeField] private Vector3 additionalRotation = new Vector3(0, -90, 0);

        [SerializeField] private Transform lightOnScene;

        public void Initiallize(Vector3 fieldCenter)
        {
            mainCamera.position = new Vector3(fieldCenter.x, fieldCenter.y + distanceBetweenFieldAndCamera, fieldCenter.z);
            var toFieldDirection = (fieldCenter - mainCamera.position).normalized;

            mainCamera.rotation = Quaternion.Euler(Quaternion.LookRotation(toFieldDirection).eulerAngles + additionalRotation);
            lightOnScene.rotation = Quaternion.LookRotation(toFieldDirection);
        }
    }
}