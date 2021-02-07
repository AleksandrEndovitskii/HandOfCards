using System;
using DG.Tweening;
using Extensions;
using TMPro;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CounterTextComponent : MonoBehaviour
    {
        public event Action<CounterTextComponent> AnimationComplete = delegate { };

        [SerializeField]
        private float _durationSecondsCount = 1;

        private TextMeshProUGUI _text;
        private Tweener _tweener;

        private void Awake()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Set(int finalValue)
        {
            int.TryParse(_text.text, out var initialValue);

            if (_tweener != null)
            {
                _tweener.onComplete -= OnTweenerONComplete;
            }
            if (initialValue == finalValue)
            {
                OnTweenerONComplete();
            }
            _tweener = _text.DOText(initialValue, finalValue, _durationSecondsCount, it => $"{it:0}").
                SetEase(Ease.Linear);
            _tweener.onComplete += OnTweenerONComplete;
        }

        private void OnTweenerONComplete()
        {
            Debug.Log("CounterTextComponent.OnTweenerONComplete");

            AnimationComplete.Invoke(this);
        }
    }
}
