using System;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class Hero : MonoBehaviour, IPointerClickHandler, IDragHandler
    {
        [SerializeField] private ActionArea _actionArea;

        public event Action<PointerEventData> Clicked;
        public event Action<PointerEventData> Dragged;
        
        public void Init(HeroData data)
        {
            _actionArea.SetDiameter(data.ActionDiameter);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Dragged?.Invoke(eventData);
        }
    }
}
