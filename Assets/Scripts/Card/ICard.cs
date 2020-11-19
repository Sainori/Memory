using System;

namespace Card
{
    public interface ICard
    {
        event Action OnOpeningEnd;
        event Action OnDestroy;

        int CardType { get; }

        void Initialize(uint cardType);
        void SelectCard();
        void UnselectCard();
        void Destroy();
    }
}