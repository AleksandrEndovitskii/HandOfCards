using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Views;

namespace Components
{
    [RequireComponent(typeof(CardView))]
    [RequireComponent(typeof(DOTweenAnimation))]
    public class CardPropertyGetOutOfBorderAnimationPlayingComponent : MonoBehaviour
    {
        [SerializeField]
        private string _propertyName;
        [SerializeField]
        private string _animationId;
        [SerializeField]
        private int _propertyMinValue;

        private CardView _cardView;
        private List<DOTweenAnimation> _doTweenAnimations;

        private void Awake()
        {
            _cardView = this.gameObject.GetComponent<CardView>();

            _doTweenAnimations = this.gameObject.GetComponents<DOTweenAnimation>()
                .Where(x => x.id == _animationId).ToList();
        }
        private void Start()
        {
            _cardView.CardModel.Value.PropertyValueChanged += CardModelOnPropertyValueChanged;
            CardModelOnPropertyValueChanged(_propertyName, "0", _cardView.CardModel.Value.HPValue.ToString());
        }
        private void OnDestroy()
        {
            _cardView.CardModel.Value.PropertyValueChanged -= CardModelOnPropertyValueChanged;
        }

        private void CardModelOnPropertyValueChanged(string propertyName, string previousValue, string currentValue)
        {
            if (propertyName != _propertyName)
            {
                return;
            }

            var isParsed = int.TryParse(currentValue, out var value);
            if (!isParsed)
            {
                return;
            }

            if (value > _propertyMinValue)
            {
                return;
            }

            Debug.Log($"Card {_cardView.CardModel.Value.Id} {propertyName} changed from {previousValue} to {currentValue}");

            _doTweenAnimations.ForEach(x =>
            {
                x.DORestartById(_animationId);
                x.onComplete.AddListener(() =>
                {
                    Destroy(this.gameObject);
                });
            });
        }
    }
}
