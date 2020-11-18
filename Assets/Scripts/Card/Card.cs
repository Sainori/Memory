using System;
using System.Collections;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour, ICard
    {
        private const string Opened = "Opened";
        private const string Closed = "Closed";

        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        [SerializeField] private float selectDuration = 1;
        [SerializeField] private float firstShowDuration = 3;

        [SerializeField] private uint _cardType;
        [SerializeField] private GameObject cardModel;

        private Animator _animator;
        private Coroutine _opening;

        private void Awake()
        {
            _animator = cardModel.GetComponent<Animator>();
        }

        public void Initialize(uint cardType)
        {
            _cardType = cardType;
            cardModel.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, (float) cardType / 4);

            StartCoroutine(OpenCard(firstShowDuration));
        }

        public void SelectCard()
        {
            _opening = StartCoroutine(OpenCard(selectDuration));
        }

        private IEnumerator OpenCard(float duration)
        {
            Debug.Log("Open card" + duration);

            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName(Closed))
            {
                Debug.Log("break");
                yield break;
            }

            _animator.SetBool(IsOpened, true);

            if (!stateInfo.IsName(Opened))
            {
                yield return null;
            }

            yield return new WaitForSeconds(duration);
            _animator.SetBool(IsOpened, false);
        }
    }
}