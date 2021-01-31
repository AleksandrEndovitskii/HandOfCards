using Models;
using UnityEngine;
using Utils;
using Views;

namespace Managers
{
    public class CardManager : MonoBehaviour, IInitilizable, IUnInitializeble
    {
        [SerializeField]
        private CardView _cardViewPrefab;

        public void Initialize()
        {
            var randomCardInstance = CreateRandomCardInstance(_cardViewPrefab,
                GameManager.Instance.UserInterfaceManager.UserInterfaceCanvasInstance.transform);
        }
        public void UnInitialize()
        {

        }

        private CardView CreateRandomCardInstance(CardView cardViewPrefab, Transform parent)
        {
            var randomCardModel = CreateRandomCardModel();

            var cardViewInstance = CreateCardInstance(cardViewPrefab, randomCardModel, parent);

            return cardViewInstance;
        }
        private CardView CreateCardInstance(CardView cardViewPrefab, CardModel cardModel, Transform parent)
        {
            var cardViewInstance = Instantiate(cardViewPrefab, parent);
            cardViewInstance.SetModel(cardModel);

            return cardViewInstance;
        }

        private static CardModel CreateRandomCardModel()
        {
            var cardModel = new CardModel(null, null, "title", "description",
                "Attack", 100,
                "HP", 100,
                "Mana", 100);
            return cardModel;
        }
    }
}
