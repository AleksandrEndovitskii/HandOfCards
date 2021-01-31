using TMPro;
using UniRx;
using UnityEngine;
using Views;

namespace Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CardDescriptionTextVisualizationComponent : MonoBehaviour
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
                cardModel.Description.Subscribe(value =>
                {
                    _text.text = value.ToString();
                });
            });
        }
    }
}
