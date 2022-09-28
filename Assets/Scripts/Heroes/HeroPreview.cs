using System;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class HeroPreview : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public bool IsPlayer { get; set; }
        public bool IsDragged { get; private set; }
        public HeroData Data { get; set; }
        public event Action<HeroPreview, PointerEventData> InteractStarted;
        public event Action<HeroPreview> InteractEnded;
        
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => 
            InteractStarted?.Invoke(this, eventData);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => 
            InteractEnded?.Invoke(this);

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            IsDragged = true;
            InteractEnded?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsDragged = false;
            InteractStarted?.Invoke(this, eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsPlayer)
            {
                transform.position = eventData.pointerCurrentRaycast.screenPosition;
            }
        }
    }
}