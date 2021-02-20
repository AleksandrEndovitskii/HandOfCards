using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class CardModel
    {
        public Action<string, string, string> PropertyValueChanged = delegate { };

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == _id)
                {
                    return;
                }

                var previousValue = _id;
                _id = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _id.ToString());
            }
        }
        public ReactiveProperty<Image> Icon { get; private set; }
        public ReactiveProperty<Image> Frame { get; private set; }
        public ReactiveProperty<string> Title { get; private set; }
        public ReactiveProperty<string> Description { get; private set; }
        public ReactiveProperty<string> AttackIconName { get; private set; }
        public int AttackValue
        {
            get
            {
                return _attackValue;
            }
            set
            {
                if (value == _attackValue)
                {
                    return;
                }

                var previousValue = _attackValue;
                _attackValue = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _attackValue.ToString());
            }
        }
        public ReactiveProperty<string> HPIconName { get; private set; }
        public int HPValue
        {
            get
            {
                return _hpValue;
            }
            set
            {
                if (value == _hpValue)
                {
                    return;
                }

                var previousValue = _hpValue;
                _hpValue = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _hpValue.ToString());
            }
        }
        public ReactiveProperty<string> ManaIconName { get; private set; }
        public int ManaValue
        {
            get
            {
                return _manaValue;
            }
            set
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

        private int _id;
        private int _attackValue;
        private int _hpValue;
        private int _manaValue;

        public CardModel(int id, Image icon, Image frame, string title, string description,
            string attackIconName, int attackValue,
            string hpIconName, int hpValue,
            string manaIconName, int manaValue)
        {
            PropertyValueChanged += (propertyName, previousValue, currentValue) =>
            {
                Debug.Log($"{GetType().Name}.{propertyName} changed from {previousValue} to {currentValue}");
            };

            Id = id;
            Icon = new ReactiveProperty<Image>(icon);
            Frame = new ReactiveProperty<Image>(frame);
            Title = new ReactiveProperty<string>(title);
            Description = new ReactiveProperty<string>(description);

            AttackIconName = new ReactiveProperty<string>(attackIconName);
            AttackValue = attackValue;

            HPIconName = new ReactiveProperty<string>(hpIconName);
            HPValue = hpValue;

            ManaIconName = new ReactiveProperty<string>(manaIconName);
            ManaValue = manaValue;
        }
    }
}
