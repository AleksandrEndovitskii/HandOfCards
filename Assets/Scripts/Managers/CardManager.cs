using System;
using System.Collections.Generic;
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

        private void CreateDemoTimerModels()
        {
            var randomCardsCount = Random.Range(_randomCardsMinCount, _randomCardsMaxCount);
            for (var i = 0; i < randomCardsCount; i++)
            {
                var randomCardModel = CreateRandomCardModel();

                Add(randomCardModel);
            }
        }

        private static CardModel CreateRandomCardModel()
        {
            var cardModel = new CardModel(null, null, "title", "description",
                "Attack", 100,
                "HP", 100,
                "Mana", 100);
            return cardModel;
        }
    }
}
