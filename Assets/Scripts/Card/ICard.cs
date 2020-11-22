using System;
using UnityEngine;

namespace Card
{
    public interface ICard
    {
        event Action OnOpeningEnd;
        event Action OnDestroy;

        int CardType { get; }

        void Initialize(uint cardType, Mesh cardReference);
        void SelectCard();
        void UnselectCard();
        void Destroy();
    }
}