using System;
using System.Collections;
using System.Collections.Generic;
using Card;
using Extensions;
using LightAndCameraSystem;
using RoundSystems.Interfaces;
using UnityEngine;

namespace PlayField
{
    public class PlayField : MonoBehaviour, IPlayField
    {
        public event Action OnGameEnd = () => { };
        private event Action OnUpdate = () => { };

        private const uint columnCount = 3;
        private const uint rowCount = 5;

        [SerializeField] private uint cardTypesCount = 5;

        [SerializeField] private Vector3 upLeftCorner;
        [SerializeField] private float spaceBetween;

        [SerializeField] private GameObject cardPrefab;

        private List<ICard> cards = new List<ICard>();
        private List<GameObject> cardObjects = new List<GameObject>();

        private IMatchSystem _matchSystem;
        private Mesh[] _cardReferences;

        public IEnumerator Initialize(IMatchSystem matchSystem, Mesh[] cardReferences, ILightAndCameraSystem lightAndCameraSystem)
        {
            _cardReferences = cardReferences;
            _matchSystem = matchSystem;
            OnUpdate += CheckGameEnd;

            lightAndCameraSystem.Initiallize(GetFieldCenterPosition());
            yield return CreateCards();
        }

        public void DirectUpdate()
        {
            OnUpdate();
        }

        public IEnumerator Reset()
        {
            cards.Clear();
            cardObjects.ForEach(Destroy);

            yield return CreateCards();

            OnUpdate = () => { };
            OnUpdate += CheckGameEnd;
        }

        private void CheckGameEnd()
        {
            if (cards.Count > 0)
            {
                return;
            }

            OnGameEnd();
            OnUpdate -= CheckGameEnd;
        }

        private IEnumerator CreateCards()
        {
            var initializeCoroutines = new List<IEnumerator>();
            var cardTypesList = GetCardTypes();

            for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    initializeCoroutines.Add(SetupCard(rowIndex, columnIndex, cardTypesList));
                }
            }

            yield return this.WaitAllCoroutines(initializeCoroutines.ToArray());
        }

        private IEnumerator SetupCard(int rowIndex, int columnIndex, Queue<uint> cardTypesList)
        {
            var cardObject = CreateCardObject(rowIndex, columnIndex);
            var card = cardObject.GetComponent<ICard>();

            var cardType = cardTypesList.Dequeue();
            cardObject.GetComponentInChildren<MeshFilter>().mesh = _cardReferences[cardType];

            card.OnOpeningEnd += OnOpeningCardEnd;
            card.OnDestroy += OnCardDestroy;

            cards.Add(card);
            cardObjects.Add(cardObject);

            return card.Initialize(cardType, _cardReferences[cardType]);
        }

        private void OnOpeningCardEnd(ICard card)
        {
            _matchSystem.TryToAddCard(card);
        }

        private void OnCardDestroy(ICard card)
        { 
            cards.Remove(card);

            card.OnDestroy -= OnCardDestroy;
            card.OnOpeningEnd -= OnOpeningCardEnd;
        }

        private GameObject CreateCardObject(int rowIndex, int columnIndex)
        {
            var cardTransform = new Vector3(upLeftCorner.x + spaceBetween * rowIndex, 
                upLeftCorner.y,
                upLeftCorner.z + spaceBetween * columnIndex);

            var cardObject = Instantiate(cardPrefab, cardTransform, Quaternion.identity, transform);
            return cardObject;
        }

        private Queue<uint> GetCardTypes()
        {
            var cardsCount = columnCount * rowCount;
            var cardTypes = new uint [cardsCount];

            var cardIndex = 0;
            for (uint cardType = 0; cardType < cardTypesCount; cardType++)
            {
                for (var i = 0; i < cardsCount / cardTypesCount; i++)
                {
                    cardTypes[cardIndex] = cardType;
                    cardIndex++;
                }
            }

            cardTypes.Shuffle();
            return new Queue<uint>(cardTypes);
        }

        private Vector3 GetFieldCenterPosition()
        {
            var cameraXPosition = (upLeftCorner.x + spaceBetween * (rowCount - 1)) / 2;
            var cameraZPosition = (upLeftCorner.z + spaceBetween * (columnCount - 1)) / 2;

            return new Vector3(cameraXPosition, upLeftCorner.y, cameraZPosition);
        }
    }
}