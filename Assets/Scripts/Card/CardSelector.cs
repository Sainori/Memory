using UnityEngine;

namespace Card
{
    public class CardSelector : MonoBehaviour, ICardSelector
    {
        [SerializeField] private Card card;

        public void SelectCard()
        {
            card.SelectCard();
        }
    }
}