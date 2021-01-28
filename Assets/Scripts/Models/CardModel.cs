using UnityEngine.UI;

namespace Models
{
    public class CardModel
    {
        public Image Icon;
        public Image Frame;
        public string Title;
        public string Description;
        public Image AttackIcon;
        public int AttackValue;
        public Image HPIcon;
        public int HPValue;
        public Image ManaIcon;
        public int ManaValue;

        public CardModel(Image icon, Image frame, string title, string description, 
            Image attackIcon, int attackValue, 
            Image hpIcon, int hpValue, 
            Image manaIcon, int manaValue)
        {
            Icon = icon;
            Frame = frame;
            Title = title;
            Description = description;

            AttackIcon = attackIcon;
            AttackValue = attackValue;

            HPIcon = hpIcon;
            HPValue = hpValue;

            ManaIcon = manaIcon;
            ManaValue = manaValue;
        }
    }
}
