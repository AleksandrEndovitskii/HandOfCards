using TMPro;
using UniRx;
using UnityEngine;
using Views;

namespace Components.Stats.Values
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HPValueTextSetterComponent : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardView;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            _cardView.CardModel.Subscribe(cardModel =>
            {
                cardModel.HPValue.Subscribe(value =>
                {
                    _text.text = value.ToString();
                });
            });
        }
    }
}
