using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class CustomHorizontalLayoutGroupView : MonoBehaviour
    {
        public Action<RectTransform> ElementAdded = delegate { };

        public List<RectTransform> Content => _content;

        private List<RectTransform> _content = new List<RectTransform>();

        private HorizontalLayoutGroup _horizontalLayoutGroup;

        private Vector2 _directionOfElementsInstantiation = Vector2.right;

        private void Awake()
        {
            _horizontalLayoutGroup = this.gameObject.GetComponent<HorizontalLayoutGroup>();
        }

        public void AddElement(RectTransform rectTransform)
        {
            rectTransform.gameObject.transform.SetParent(this.gameObject.transform);

            var layoutElement = rectTransform.gameObject.GetComponent<LayoutElement>();

            var indexOfElement = _content.Count;

            var elementPositionX = _directionOfElementsInstantiation.x * indexOfElement * layoutElement.preferredWidth;
            elementPositionX += _directionOfElementsInstantiation.x * indexOfElement * _horizontalLayoutGroup.spacing;

            elementPositionX += _directionOfElementsInstantiation.x * _horizontalLayoutGroup.padding.left;

            rectTransform.anchoredPosition = new Vector2(elementPositionX , _horizontalLayoutGroup.padding.top);

            _content.Add(rectTransform);
            ElementAdded.Invoke(rectTransform);
        }
    }
}
