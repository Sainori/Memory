using System;
using System.Collections;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour, ICard
    {
        public event Action OnOpeningEnd = () => { };

        public int CardType => (int) _cardType;

        private const string Opened = "Opened";
        private const string Closed = "Closed";

        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        [SerializeField] private float firstShowDuration = 3;

        [SerializeField] private uint _cardType;
        [SerializeField] private GameObject cardModel;
        [SerializeField] private CardState cardState;

        private Animator _animator;

        private void Awake()
        {
            _animator = cardModel.GetComponent<Animator>();
        }

        public void Initialize(uint cardType)
        {
            _cardType = cardType;
            cardState = CardState.Closed;

            SetView(cardType);
            StartCoroutine(ShowCardFirstTime(firstShowDuration));
        }

        private void SetView(uint cardType)
        {
            cardModel.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, (float) cardType / 4);
        }

        public void SelectCard()
        {
            if (cardState != CardState.Closed)
            {
                return;
            }

            StartCoroutine(OpenCard());
        }

        public void UnselectCard()
        {
            if (cardState != CardState.Opened)
            {
                return;
            }

            StartCoroutine(CloseCard());
        }

        public void Destroy()
        {
            OnOpeningEnd = null;
            Destroy(gameObject);
        }

        private IEnumerator ShowCardFirstTime(float duration)
        {
            yield return OpenCard(true);
            yield return new WaitForSeconds(duration);
            yield return CloseCard();
        }

        private IEnumerator OpenCard(bool ignoreAction = false)
        {
            cardState = CardState.Opening;

            yield return WaitForState(Closed);
            _animator.SetBool(IsOpened, true);
            yield return (WaitForState(Opened));

            cardState = CardState.Opened;

            if (ignoreAction)
            {
                yield break;
            }

            OnOpeningEnd();
        }

        private IEnumerator CloseCard()
        {
            cardState = CardState.Closing;

            yield return (WaitForState(Opened));
            _animator.SetBool(IsOpened, false);
            yield return (WaitForState(Closed));

            cardState = CardState.Closed;
        }

        private IEnumerator WaitForState(string stateName)
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            while (!stateInfo.IsName(stateName))
            {
                yield return null;
                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            }
        }
    }

    enum CardState
    {
        Opened,
        Opening,
        Closed,
        Closing
    }
}