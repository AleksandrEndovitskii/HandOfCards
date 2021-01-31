using TMPro;
using UniRx;
using UnityEngine;
using Views;

namespace Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CardTitleTextVisualizationComponent : MonoBehaviour
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
                cardModel.Title.Subscribe(value =>
                {
                    _text.text = value.ToString();
                });
            });
        }
    }
}
