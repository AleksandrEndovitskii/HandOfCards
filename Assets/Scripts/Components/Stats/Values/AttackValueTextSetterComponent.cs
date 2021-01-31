using TMPro;
using UniRx;
using UnityEngine;
using Views;

namespace Components.Stats.Values
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(CounterTextComponent))]
    public class AttackValueTextSetterComponent : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardView;

        private CounterTextComponent _counterTextComponent;

        private void Awake()
        {
            _counterTextComponent = this.gameObject.GetComponent<CounterTextComponent>();
        }
        private void Start()
        {
            _cardView.CardModel.Subscribe(cardModel =>
            {
                cardModel.AttackValue.Subscribe(value =>
                {
                    _counterTextComponent.Set(value);
                });
            });
        }
    }
}
