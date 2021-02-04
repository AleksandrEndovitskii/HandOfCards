using System.Reflection;
using Models;
using TMPro;
using UniRx;
using UnityEngine;
using Views;

namespace Components.Stats.Values
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(CounterTextComponent))]
    public class CardModelPropertyValueChangedCounterTextSetterComponent : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardView;
        [SerializeField]
        private string _propertyName;

        private CounterTextComponent _counterTextComponent;

        private void Awake()
        {
            _counterTextComponent = this.gameObject.GetComponent<CounterTextComponent>();
        }
        private void Start()
        {
            _cardView.CardModel.Subscribe(CarModelChanged);
            CarModelChanged(_cardView.CardModel.Value);
        }

        private void CarModelChanged(CardModel cardModel)
        {
            cardModel.PropertyValueChanged += PropertyValueChanged;

            SetInitialValue(cardModel);
        }

        private void SetInitialValue(CardModel cardModel)
        {
            var propertyInfos = cardModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                var obj = (object) cardModel;
                var value = propertyInfo.GetValue(obj);
                PropertyValueChanged(propertyInfo.Name, "", value.ToString());
            }
        }

        private void PropertyValueChanged(string propertyName, string previousValue, string currentValue)
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

            _counterTextComponent.Set(value);
        }
    }
}
