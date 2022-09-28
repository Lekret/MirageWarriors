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
        [Tooltip("Field is exposed for tree debugger")]
        [SerializeField] private BehaviorTree _bt;
        
        public HeroData Data { get; private set; }
        public HeroState State { get; private set; }
        public IEnumerable<Hero> NearestHeroes => _actionArea.NearestHeroes;
        public BehaviorTree Bt => _bt;
        public event Action<Hero> PointerEntered;
        public event Action<Hero> PointerExited; 
        public event Action<Hero> PointerClicked;
        
        public void Init(HeroData data, bool isPlayer)
        {
            Data = data;
            State = new HeroState(data, isPlayer);
            _actionArea.SetDiameter(data.ActionDiameter);
        }

        public void SetBt(BehaviorTree bt)
        {
            _bt = bt;
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => PointerEntered?.Invoke(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => PointerExited?.Invoke(this);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => PointerClicked?.Invoke(this);
    }
}
