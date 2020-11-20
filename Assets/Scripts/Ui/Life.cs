using UnityEngine;

namespace Ui
{
    public class Life : MonoBehaviour
    {
        [SerializeField] private GameObject activeVersion;
        [SerializeField] private GameObject emptyVersion;

        private void Awake()
        {
            ActivateLife();
        }

        private void SetState(bool isActive)
        {
            activeVersion.SetActive(isActive);
            emptyVersion.SetActive(!isActive);
        }

        public void ActivateLife()
        {
            SetState(true);
        }

        public void DeactivateLife()
        {
            SetState(false);
        }
    }
}