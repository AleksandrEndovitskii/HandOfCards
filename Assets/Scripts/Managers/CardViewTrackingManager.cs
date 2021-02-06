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

        private Dictionary<CardView, List<CounterTextComponent>> _waitingForComplitionOfAnimationCardViewCounterTextComponents =
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
            foreach (var counterTextComponent in counterTextComponents)
            {
                if (_trackedCounterTextComponents.Contains(counterTextComponent))
                {
                    continue;
                }

                _trackedCounterTextComponents.Add(counterTextComponent);
                Debug.Log("CounterTextComponent added to CardViewTrackingManager");

                counterTextComponent.AnimationComplete += CounterTextComponentOnAnimationComplete;
            }

            _waitingForComplitionOfAnimationCardViewCounterTextComponents[cardView] = counterTextComponents;

            CardViewAdded.Invoke(cardView);
        }

        private void CounterTextComponentOnAnimationComplete(CounterTextComponent counterTextComponent)
        {
            Debug.Log("CardViewTrackingManager.CounterTextComponentOnAnimationComplete");

            if (_waitingForComplitionOfAnimationCardViewCounterTextComponents.All(x =>
                !x.Value.Contains(counterTextComponent)))
            {
                return;
            }
            var keyValuePair = _waitingForComplitionOfAnimationCardViewCounterTextComponents.FirstOrDefault(x =>
                x.Value.Contains(counterTextComponent));
            keyValuePair.Value.Remove(counterTextComponent);

            if (keyValuePair.Value.Count == 0)
            {
                CardViewCounterTextComponentAnimationsCompleted.Invoke(keyValuePair.Key);
            }
        }
    }
}
