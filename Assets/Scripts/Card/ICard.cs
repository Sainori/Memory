using System;
using System.Collections;
using UnityEngine;

namespace Card
{
    public interface ICard
    {
        event Action<ICard> OnOpeningEnd;
        event Action<ICard> OnDestroy;

        int CardType { get; }

        IEnumerator Initialize(uint cardType, Mesh cardReference);
        void SelectCard();
        void UnselectCard();
        void Destroy();
    }
}