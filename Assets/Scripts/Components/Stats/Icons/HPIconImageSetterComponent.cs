using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Components.Stats.Icons
{
    [RequireComponent(typeof(Image))]
    public class HPIconImageSetterComponent : MonoBehaviour
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
                cardModel.HPIconName.Subscribe(iconName =>
                {
                    _image.sprite = Resources.Load<Sprite>("Sprites/" + iconName);
                });
            });
        }
    }
}
