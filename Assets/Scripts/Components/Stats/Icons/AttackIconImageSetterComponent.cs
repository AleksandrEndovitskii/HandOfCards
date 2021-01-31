using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Components.Stats.Icons
{
    [RequireComponent(typeof(Image))]
    public class AttackIconImageSetterComponent : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardView;

        private Image _image;

        private void Awake()
        {
            _image = this.gameObject.GetComponent<Image>();
        }
        private void Start()
        {
            _cardView.CardModel.Subscribe(cardModel =>
            {
                cardModel.AttackIconName.Subscribe(iconName =>
                {
                    _image.sprite = Resources.Load<Sprite>("Sprites/" + iconName);
                });
            });
        }
    }
}
