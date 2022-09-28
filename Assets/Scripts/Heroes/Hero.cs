using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class Hero : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private ActionArea _actionArea;
        [SerializeField] private BehaviorTree _debugBt;
        
        public HeroData Data { get; private set; }
        public HeroState State { get; private set; }
        public IEnumerable<Hero> NearestHeroes => _actionArea.NearestHeroes;
        public BehaviorTree Bt => _debugBt;
        public event Action<Hero> PointerEntered;
        public event Action<Hero> PointerExited; 
        public event Action<Hero> PointerClicked;
        
        public void Init(HeroData data, bool isPlayer)
        {
            Data = data;
            State = new HeroState(data, isPlayer);
            _actionArea.SetDiameter(data.ActionDiameter);
        }

        public void SetBehaviorTree(BehaviorTree bt)
        {
            _debugBt = bt;
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            PointerEntered?.Invoke(this);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            PointerExited?.Invoke(this);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            PointerClicked?.Invoke(this);
        }
    }
}
