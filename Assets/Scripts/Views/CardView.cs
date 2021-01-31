using Models;
using UniRx;
using UnityEngine;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        public ReactiveProperty<CardModel> CardModel { get; private set; }

        public void SetModel(CardModel cardModel)
        {
            CardModel = new ReactiveProperty<CardModel>(cardModel);
        }
    }
}
