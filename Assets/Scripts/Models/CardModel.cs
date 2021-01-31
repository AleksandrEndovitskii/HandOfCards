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
        public ReactiveProperty<string> AttackIconName { get; private set; }
        public ReactiveProperty<int> AttackValue { get; private set; }
        public ReactiveProperty<string> HPIconName { get; private set; }
        public ReactiveProperty<int> HPValue { get; private set; }
        public ReactiveProperty<string> ManaIconName { get; private set; }
        public ReactiveProperty<int> ManaValue { get; private set; }

        public CardModel(Image icon, Image frame, string title, string description,
            string attackIconName, int attackValue,
            string hpIconName, int hpValue, 
            string manaIconName, int manaValue)
        {
            Icon = new ReactiveProperty<Image>(icon);
            Frame = new ReactiveProperty<Image>(frame);
            Title = new ReactiveProperty<string>(title);
            Description = new ReactiveProperty<string>(description);

            AttackIconName = new ReactiveProperty<string>(attackIconName);
            AttackValue = new ReactiveProperty<int>(attackValue);

            HPIconName = new ReactiveProperty<string>(hpIconName);
            HPValue = new ReactiveProperty<int>(hpValue);

            ManaIconName = new ReactiveProperty<string>(manaIconName);
            ManaValue = new ReactiveProperty<int>(manaValue);
        }
    }
}
