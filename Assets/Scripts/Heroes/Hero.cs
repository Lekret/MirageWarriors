using System;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class Hero : MonoBehaviour, IPointerClickHandler, IDragHandler
    {
        [SerializeField] private ActionArea _actionArea;
        
        public void Init(HeroData data)
        {
            _actionArea.SetDiameter(data.ActionDiameter);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.LogError("Clicked omg!");
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }
    }
}
