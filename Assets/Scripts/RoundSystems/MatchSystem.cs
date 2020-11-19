using System.Collections.Generic;
using Card;
using RoundSystems.Interfaces;
using UnityEngine;

namespace RoundSystems
{
    public class MatchSystem : IMatchSystem
    {
        private const uint PointsPerFullMatch = 3;
        private const int PointsPerHalfMatch = 1;

        private int _cardType;

        private readonly uint _matchCardsCount;
        private readonly ILivesSystem _livesSystem;
        private readonly IScoreSystem _scoreSystem;

        private List<ICard> _selectedCards;

        public MatchSystem(ILivesSystem livesSystem, IScoreSystem scoreSystem, uint matchCardsCount = 3)
        {
            _livesSystem = livesSystem;
            _scoreSystem = scoreSystem;

            _cardType = -1;
            _matchCardsCount = matchCardsCount;
            _selectedCards = new List<ICard>((int) matchCardsCount);
        }

        public void TryToAddCard(ICard card)
        {
            if (_cardType == -1)
            {
                _cardType = card.CardType;
            }

            if (_selectedCards.Contains(card))
            {
                return;
            }

            _selectedCards.Add(card);

            if (_cardType != card.CardType)
            {
                _selectedCards.ForEach(selectedCard => selectedCard.UnselectCard());
                _livesSystem.RemoveLife();
                ResetSelectedCards();
                return;
            }

            var pointsMultiplier = _selectedCards.Count == _matchCardsCount ? PointsPerFullMatch : PointsPerHalfMatch;
            _scoreSystem.AddPoints(_livesSystem.Lives * pointsMultiplier);

            if (_selectedCards.Count != _matchCardsCount)
            {
                return;
            }

            _selectedCards.ForEach(selectedCard => selectedCard.Destroy());
            ResetSelectedCards();
        }

        private void ResetSelectedCards()
        {
            _selectedCards.Clear();
            _cardType = -1;
        }
    }
}