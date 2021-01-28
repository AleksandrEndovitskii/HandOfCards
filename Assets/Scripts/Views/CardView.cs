using Models;
using UniRx;
using UnityEngine;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        public ReactiveProperty<CardModel> CardModel { get; private set; }

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
            CardModel = new ReactiveProperty<CardModel>(cardModel);
        }
    }
}
