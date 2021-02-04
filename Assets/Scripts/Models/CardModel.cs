using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class CardModel
    {
        public Action<string, string, string> PropertyValueChanged = delegate { };

        public ReactiveProperty<Image> Icon { get; private set; }
        public ReactiveProperty<Image> Frame { get; private set; }
        public ReactiveProperty<string> Title { get; private set; }
        public ReactiveProperty<string> Description { get; private set; }
        public ReactiveProperty<string> AttackIconName { get; private set; }
        public ReactiveProperty<int> AttackValue { get; private set; }
        public ReactiveProperty<string> HPIconName { get; private set; }
        public ReactiveProperty<int> HPValue { get; private set; }
        public ReactiveProperty<string> ManaIconName { get; private set; }
        public int ManaValue
        {
            get
            {
                return _manaValue;
            }
            private set
            {
                if (value == _manaValue)
                {
                    return;
                }

                var previousValue = _manaValue;
                _manaValue = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _manaValue.ToString());
            }
        }

        private int _manaValue;

        public CardModel(Image icon, Image frame, string title, string description,
            string attackIconName, int attackValue,
            string hpIconName, int hpValue, 
            string manaIconName, int manaValue)
        {
            PropertyValueChanged += (propertyName, previousValue, currentValue) =>
            {
                Debug.Log($"{GetType().Name}.{propertyName} changed from {previousValue} to {currentValue}");
            };

            Icon = new ReactiveProperty<Image>(icon);
            Frame = new ReactiveProperty<Image>(frame);
            Title = new ReactiveProperty<string>(title);
            Description = new ReactiveProperty<string>(description);

            AttackIconName = new ReactiveProperty<string>(attackIconName);
            AttackValue = new ReactiveProperty<int>(attackValue);

            HPIconName = new ReactiveProperty<string>(hpIconName);
            HPValue = new ReactiveProperty<int>(hpValue);

            ManaIconName = new ReactiveProperty<string>(manaIconName);
            ManaValue = manaValue;
        }
    }
}
