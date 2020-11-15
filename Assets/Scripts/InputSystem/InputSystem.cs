using UnityEngine;

namespace InputSystem
{
    public class InputSystem : MonoBehaviour, IInputSystem
    {
        public void DirectUpdate()
        {
            var touch = Input.GetMouseButtonUp(0);
            if (touch)
            {
                Debug.Log("Touch ended");
            }
        }
    }
}