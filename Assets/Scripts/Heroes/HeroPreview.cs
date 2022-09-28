﻿using System;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class HeroPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        public bool IsPlayer { get; set; }
        public HeroData Data { get; set; }
        public event Action<HeroPreview> PointerEntered;
        public event Action<HeroPreview> PointerExited;
        
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => PointerEntered?.Invoke(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => PointerExited?.Invoke(this);
        
        public void OnDrag(PointerEventData eventData)
        {
            if (IsPlayer)
            {
                transform.position = eventData.pointerCurrentRaycast.worldPosition;
            }
        }
    }
}