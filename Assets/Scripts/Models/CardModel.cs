using UniRx;
using UnityEngine.UI;

namespace Models
{
    public class CardModel
    {
        public ReactiveProperty<Image> Icon { get; private set; }
        public ReactiveProperty<Image> Frame { get; private set; }
        public ReactiveProperty<string> Title { get; private set; }
        public ReactiveProperty<string> Description { get; private set; }
        public ReactiveProperty<Image> AttackIcon { get; private set; }
        public ReactiveProperty<int> AttackValue { get; private set; }
        public ReactiveProperty<Image> HPIcon { get; private set; }
        public ReactiveProperty<int> HPValue { get; private set; }
        public ReactiveProperty<Image> ManaIcon { get; private set; }
        public ReactiveProperty<int> ManaValue { get; private set; }

        public CardModel(Image icon, Image frame, string title, string description, 
            Image attackIcon, int attackValue, 
            Image hpIcon, int hpValue, 
            Image manaIcon, int manaValue)
        {
            Icon = new ReactiveProperty<Image>(icon);
            Frame = new ReactiveProperty<Image>(frame);
            Title = new ReactiveProperty<string>(title);
            Description = new ReactiveProperty<string>(description);

            AttackIcon = new ReactiveProperty<Image>(attackIcon);
            AttackValue = new ReactiveProperty<int>(attackValue);

            HPIcon = new ReactiveProperty<Image>(hpIcon);
            HPValue = new ReactiveProperty<int>(hpValue);

            ManaIcon = new ReactiveProperty<Image>(manaIcon);
            ManaValue = new ReactiveProperty<int>(manaValue);
        }
    }
}
