using System.Collections.Generic;
using Managers;
using Models;
using UnityEngine;
using Views;

namespace Factories
{
    public class CardsViewsFactory : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private CardView _cardViewPrefab;
#pragma warning restore 0649

        private List<CardView> _cardViewInstances = new List<CardView>();

        public CardView Create(CardModel cardModel, Transform parent)
        {
            var instance = Instantiate(_cardViewPrefab, parent);
            instance.SetModel(cardModel);
            _cardViewInstances.Add(instance);
            GameManager.Instance.CardViewTrackingManager.Track(instance);
            return instance;
        }
    }
}
