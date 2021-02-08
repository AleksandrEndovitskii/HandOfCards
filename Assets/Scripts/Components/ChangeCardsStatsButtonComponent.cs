using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(Button))]
    public class ChangeCardsStatsButtonComponent : MonoBehaviour
    {
        private Button _button;
        private CardManager _cardManager;

        private void Awake()
        {
            _button = this.gameObject.GetComponent<Button>();

            _cardManager = GameManager.Instance.CardManager;
        }
        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log("ChangeCardsStatsButtonComponent");

            _cardManager.StartCardsStatsRandomlyChanging();
        }
    }
}
