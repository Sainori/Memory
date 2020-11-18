using System;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour, ICard
    {
        private uint _cardType;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Initialize(uint cardType)
        {
            _cardType = cardType;
            Debug.Log(cardType);
        }
    }
}