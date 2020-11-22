using System;
using System.Collections;
using UnityEngine;

namespace Card
{
    public interface ICard
    {
        event Action OnOpeningEnd;
        event Action OnDestroy;

        int CardType { get; }

        IEnumerator Initialize(uint cardType, Mesh cardReference);
        void SelectCard();
        void UnselectCard();
        void Destroy();
    }
}