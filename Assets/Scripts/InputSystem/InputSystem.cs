using Card;
using UnityEngine;

namespace InputSystem
{
    public class InputSystem : MonoBehaviour, IInputSystem
    {
        public void DirectUpdate()
        {
            if (!TryGetInputPosition(out var inputPosition))
            {
                return;
            }

            CastRay(inputPosition);
        }

        private bool TryGetInputPosition(out Vector3 inputPosition)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    return TryGetMouseClick(out inputPosition);

                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    return TryGetTouch(out inputPosition);

                default:
                    inputPosition = default;
                    return false;
            }
        }

        private bool TryGetTouch(out Vector3 inputPosition)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Ended)
            {
                inputPosition = default;
                return false;
            }

            inputPosition = touch.position;
            return true;
        }

        private bool TryGetMouseClick(out Vector3 inputPosition)
        {
            var mouseButtonUp = Input.GetMouseButtonUp(0);
            if (!mouseButtonUp)
            {
                inputPosition = default;
                return false;
            }

            inputPosition = Input.mousePosition;
            return true;
        }

        private void CastRay(Vector3 position)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
            {
                return;
            }

            var card = hit.transform.GetComponent<ICardSelector>();
            card?.SelectCard();
        }
    }
}