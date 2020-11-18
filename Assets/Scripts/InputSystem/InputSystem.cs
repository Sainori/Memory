using Card;
using UnityEngine;

namespace InputSystem
{
    public class InputSystem : MonoBehaviour, IInputSystem
    {
        //TODO: implement touch for smartphone
        public void DirectUpdate()
        {
            var touch = Input.GetMouseButtonUp(0);
            if (!touch)
            {
                return;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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