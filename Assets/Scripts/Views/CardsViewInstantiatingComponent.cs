using System.Collections.Generic;
using Managers;
using Models;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(CustomHorizontalLayoutGroupView))]
    public class CardsViewInstantiatingComponent : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardViewPrefab;

        private List<CardView> _cardViewInstances = new List<CardView>();

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
            var cardViewInstance = InstantiateElement(cardModel, _cardViewPrefab, GameManager.Instance.UserInterfaceManager.UserInterfaceCanvasInstance.transform);
            _cardViewInstances.Add(cardViewInstance);
            GameManager.Instance.CardViewTrackingManager.Track(cardViewInstance);
            _customHorizontalLayoutGroupView.AddElement(cardViewInstance.gameObject.GetComponent<RectTransform>());
        }

        private CardView InstantiateElement(CardModel cardModel, CardView cardViewPrefab, Transform parent)
        {
            var instance = Instantiate(cardViewPrefab, parent);
            instance.SetModel(cardModel);
            return instance;
        }
    }
}
