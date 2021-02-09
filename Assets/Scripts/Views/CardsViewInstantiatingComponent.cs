using System.Collections.Generic;
using Managers;
using Models;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(CustomHorizontalLayoutGroupView))]
    public class CardsViewInstantiatingComponent : MonoBehaviour
    {
        private CustomHorizontalLayoutGroupView _customHorizontalLayoutGroupView;

        private CardManager _cardManager;

        private void Awake()
        {
            _customHorizontalLayoutGroupView = this.gameObject.GetComponent<CustomHorizontalLayoutGroupView>();
            _cardManager = GameManager.Instance.CardManager;
        }
        private void Start()
        {
            _cardManager.CardModelAdded += OnCardModelAdded;
            foreach (var cardModel in _cardManager.CardModels)
            {
                OnCardModelAdded(cardModel);
            }
        }
        private void OnDestroy()
        {
            _cardManager.CardModelAdded -= OnCardModelAdded;
        }

        private void OnCardModelAdded(CardModel cardModel)
        {
            AddElement(cardModel);
        }

        private void AddElement(CardModel cardModel)
        {
            var cardViewInstance = GameManager.Instance.CardsViewsFactory.Create(cardModel,
                GameManager.Instance.UserInterfaceManager.UserInterfaceCanvasInstance.transform);
            _customHorizontalLayoutGroupView.AddElement(cardViewInstance.gameObject.GetComponent<RectTransform>());
        }
    }
}
