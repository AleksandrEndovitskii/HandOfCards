using Models;
using UnityEngine;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        private CardModel _cardModel;

        private void Start()
        {
            // TODO: test data
            var cardModel = new CardModel(null, null, "title", "description",
                null, 1,
                null, 1,
                null, 1);
            SetModel(cardModel);
        }

        public void SetModel(CardModel cardModel)
        {
            _cardModel = cardModel;
        }
    }
}
