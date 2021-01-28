using DG.Tweening;
using Extensions;
using TMPro;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CounterTextComponent : MonoBehaviour
    {
        [SerializeField]
        private float _durationSecondsCount = 1;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Set(int finalValue)
        {
            int.TryParse(_text.text, out var initialValue);

            _text.DOText(initialValue, finalValue, _durationSecondsCount, it => $"{it:0}").SetEase(Ease.Linear);
        }
    }
}
