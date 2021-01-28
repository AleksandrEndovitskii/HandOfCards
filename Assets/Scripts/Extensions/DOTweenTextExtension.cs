using System;
using DG.Tweening;
using TMPro;

namespace Extensions
{
    public static class DOTweenTextExtension
    {
        public static Tweener DOText(this TextMeshProUGUI text, int initialValue, int finalValue, float duration,
            Func<int, string> convertor)
        {
            return DOTween.To(
                () => initialValue,
                it => text.text = convertor(it),
                finalValue,
                duration
            );
        }

        public static Tweener DOText(this TextMeshProUGUI text, int initialValue, int finalValue, float duration)
        {
            return DOTweenTextExtension.DOText(text, initialValue, finalValue, duration, it => it.ToString());
        }

        public static Tweener DOText(this TextMeshProUGUI text, float initialValue, float finalValue, float duration,
            Func<float, string> convertor)
        {
            return DOTween.To(
                () => initialValue,
                it => text.text = convertor(it),
                finalValue,
                duration
            );
        }

        public static Tweener DOText(this TextMeshProUGUI text, float initialValue, float finalValue, float duration)
        {
            return DOTweenTextExtension.DOText(text, initialValue, finalValue, duration, it => it.ToString());
        }

        public static Tweener DOText(this TextMeshProUGUI text, long initialValue, long finalValue, float duration,
            Func<long, string> convertor)
        {
            return DOTween.To(
                () => initialValue,
                it => text.text = convertor(it),
                finalValue,
                duration
            );
        }

        public static Tweener DOText(this TextMeshProUGUI text, long initialValue, long finalValue, float duration)
        {
            return DOTweenTextExtension.DOText(text, initialValue, finalValue, duration, it => it.ToString());
        }

        public static Tweener DOText(this TextMeshProUGUI text, double initialValue, double finalValue, float duration,
            Func<double, string> convertor)
        {
            return DOTween.To(
                () => initialValue,
                it => text.text = convertor(it),
                finalValue,
                duration
            );
        }

        public static Tweener DOText(this TextMeshProUGUI text, double initialValue, double finalValue, float duration)
        {
            return DOTweenTextExtension.DOText(text, initialValue, finalValue, duration, it => it.ToString());
        }
    }
}
