using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using UnityEngine;
using Utils;
using Views;

namespace Managers
{
    public class CardViewTrackingManager : MonoBehaviour, IInitilizable, IUnInitializeble
    {
        public Action<CardView> CardViewAdded = delegate { };
        public Action<CardView> CardViewCounterTextComponentAnimationsCompleted = delegate { };

        private List<CardView> _trackedCardViews = new List<CardView>();
        private List<CounterTextComponent> _trackedCounterTextComponents = new List<CounterTextComponent>();

        private Dictionary<CardView, List<CounterTextComponent>> _cardViewCounterTextComponents =
            new Dictionary<CardView, List<CounterTextComponent>>();

        public void Initialize()
        {

        }
        public void UnInitialize()
        {

        }

        public void Track(CardView cardView)
        {
            if (_trackedCardViews.Contains(cardView))
            {
                return;
            }

            Add(cardView);
        }

        private void Add(CardView cardView)
        {
            _trackedCardViews.Add(cardView);
            Debug.Log("CardView added to CardViewTrackingManager");

            var counterTextComponents = cardView.gameObject.GetComponentsInChildren<CounterTextComponent>().ToList();
            _cardViewCounterTextComponents[cardView] = counterTextComponents;
            foreach (var counterTextComponent in counterTextComponents)
            {
                if (_trackedCounterTextComponents.Contains(counterTextComponent))
                {
                    continue;
                }

                _trackedCounterTextComponents.Add(counterTextComponent);
                Debug.Log("CounterTextComponent added to CardViewTrackingManager");

                counterTextComponent.AnimationCompleted += CounterTextComponentOnAnimationCompleted;
            }

            CardViewAdded.Invoke(cardView);
        }

        private void CounterTextComponentOnAnimationCompleted(CounterTextComponent counterTextComponent)
        {
            Debug.Log("CardViewTrackingManager.CounterTextComponentOnAnimationComplete");

            if (_cardViewCounterTextComponents.All(x =>
                !x.Value.Contains(counterTextComponent)))
            {
                return;
            }

            var keyValuePair = _cardViewCounterTextComponents.FirstOrDefault(x =>
                x.Value.Contains(counterTextComponent));

            CardViewCounterTextComponentAnimationsCompleted.Invoke(keyValuePair.Key);
        }
    }
}
