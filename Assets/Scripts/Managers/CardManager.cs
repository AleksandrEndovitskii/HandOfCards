using Models;
using UnityEngine;
using Views;

namespace Managers
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField]
        private CardView _cardViewPrefab;
        [SerializeField]
        private Canvas _canvasInstance;

        private void Start()
        {
            // TODO: test data
            var cardViewInstance = Instantiate(_cardViewPrefab, _canvasInstance.transform);
            var cardModel = new CardModel(null, null, "title", "description",
                "Attack", 1,
                "HP", 1,
                "Mana", 1);
            cardViewInstance.SetModel(cardModel);
        }
    }
}
