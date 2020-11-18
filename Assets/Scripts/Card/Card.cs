using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour, ICard
    {
        [SerializeField] private uint _cardType;
        [SerializeField] private GameObject cardModel;

        private Animator _animator;

        private static readonly int IsOpened = Animator.StringToHash("IsOpened");
        private static readonly int OpeningState = Animator.StringToHash("Opening");
        private static readonly int ClosingState = Animator.StringToHash("Closing");

        private void Awake()
        {
            _animator = cardModel.GetComponent<Animator>();
        }

        public void Initialize(uint cardType)
        {
            _cardType = cardType;
            cardModel.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, (float) cardType / 4);
        }

        public void SelectCard()
        {
            _animator.SetBool(IsOpened, !_animator.GetBool(IsOpened));
        }
    }
}