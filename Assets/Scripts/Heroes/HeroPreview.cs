using System;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class HeroPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        public bool IsPlayer { get; set; }
        public HeroData Data { get; set; }
        public event Action<HeroPreview, PointerEventData> PointerEntered;
        public event Action<HeroPreview> PointerExited;

        private bool _entered;
        
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (_entered)
                return;
            PointerEntered?.Invoke(this, eventData);
            _entered = true;
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!_entered)
                return;
            PointerExited?.Invoke(this);
            _entered = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsPlayer)
            {
                transform.position = eventData.pointerCurrentRaycast.worldPosition;
            }
        }
    }
}