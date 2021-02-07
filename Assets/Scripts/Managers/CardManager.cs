using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Models;
using UnityEngine;
using Utils;
using Views;
using Random = UnityEngine.Random;

namespace Managers
{
    public class CardManager : MonoBehaviour, IInitilizable, IUnInitializeble
    {
        public Action<CardModel> CardModelAdded = delegate { };

        [SerializeField]
        private CardsViewInstantiatingComponent cardsViewInstantiatingComponentPrefab;

        [SerializeField]
        private int _randomCardsMinCount = 3;
        [SerializeField]
        private int _randomCardsMaxCount = 6;

        [SerializeField]
        private int _cardAttackDefaultValue = 5;
        [SerializeField]
        private int _cardHPDefaultValue = 15;
        [SerializeField]
        private int _cardManaDefaultValue = 10;

        [SerializeField]
        private int _minValue = -2;
        [SerializeField]
        private int _maxValue = 9;

        public List<CardModel> CardModels = new List<CardModel>();

        private List<CardModel> _cardModelsWithRandomlySettedStats = new List<CardModel>();

        private CardsViewInstantiatingComponent _cardsViewInstantiatingComponentInstance;

        public void Initialize()
        {
            _cardsViewInstantiatingComponentInstance = Instantiate(cardsViewInstantiatingComponentPrefab,
                GameManager.Instance.UserInterfaceManager.UserInterfaceCanvasInstance.transform);

            CreateDemoTimerModels();

            GameManager.Instance.CardViewTrackingManager.CardViewCounterTextComponentAnimationsCompleted +=
                OnCardViewCounterTextComponentAnimationsCompleted;
        }
        public void UnInitialize()
        {
            GameManager.Instance.CardViewTrackingManager.CardViewCounterTextComponentAnimationsCompleted -=
                OnCardViewCounterTextComponentAnimationsCompleted;
        }

        public void Add(CardModel cardModel)
        {
            CardModels.Add(cardModel);

            CardModelAdded.Invoke(cardModel);
        }

        public void ChangeCardsStatsRandomly()
        {
            _cardModelsWithRandomlySettedStats.Clear();

            SetRandomStatsForNextCardModel(_minValue, _maxValue);
        }

        private void SetRandomStatsForNextCardModel(int minValue, int maxValue)
        {
            var cardModel = CardModels.FirstOrDefault(x => !_cardModelsWithRandomlySettedStats.Contains(x));
            if (cardModel == null)
            {
                return;
            }

            var propertyInfos = cardModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                // only interested in stats properties - their type - int
                // TODO: re-implement this in more efficient way
                if (propertyInfo.PropertyType != typeof(int))
                {
                    continue;
                }

                var randomValue = Random.Range(minValue, maxValue);
                PropertyInfoExtensions.SetValue(propertyInfo, cardModel, randomValue);
            }

            _cardModelsWithRandomlySettedStats.Add(cardModel);
        }

        private void CreateDemoTimerModels()
        {
            var randomCardsCount = Random.Range(_randomCardsMinCount, _randomCardsMaxCount);
            for (var i = 0; i < randomCardsCount; i++)
            {
                var randomCardModel = CreateRandomCardModel();

                Add(randomCardModel);
            }
        }

        private CardModel CreateRandomCardModel()
        {
            var cardModel = new CardModel(null, null, "title", "description",
                "Attack", _cardAttackDefaultValue,
                "HP", _cardHPDefaultValue,
                "Mana", _cardManaDefaultValue);
            return cardModel;
        }

        private void OnCardViewCounterTextComponentAnimationsCompleted(CardView cardView)
        {
            if (!_cardModelsWithRandomlySettedStats.Contains(cardView.CardModel.Value))
            {
                return;
            }

            SetRandomStatsForNextCardModel(_minValue, _maxValue);
        }
    }
}
