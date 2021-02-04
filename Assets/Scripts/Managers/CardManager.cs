using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<CardModel> CardModels = new List<CardModel>();

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

        private CardsViewInstantiatingComponent _cardsViewInstantiatingComponentInstance;

        public void Initialize()
        {
            _cardsViewInstantiatingComponentInstance = Instantiate(cardsViewInstantiatingComponentPrefab, 
                GameManager.Instance.UserInterfaceManager.UserInterfaceCanvasInstance.transform);

            CreateDemoTimerModels();
        }
        public void UnInitialize()
        {

        }

        public void Add(CardModel cardModel)
        {
            CardModels.Add(cardModel);

            CardModelAdded.Invoke(cardModel);
        }

        public void ChangeCardsStatsRandomly(int minValue, int maxValue)
        {
            var firstCardModel = CardModels.FirstOrDefault();
            if (firstCardModel == null)
            {
                return;
            }

            var randomValue = Random.Range(minValue, maxValue);
            firstCardModel.HPValue.Value = randomValue;
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
    }
}
