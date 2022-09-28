using System;
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

        public bool IsPlayer { get; private set; }
        public HeroData Data { get; private set; }
        public HeroState State { get; private set; }

        public event Action<Hero> PointerEntered;
        public event Action<Hero> PointerExited; 
        public event Action<Hero> PointerClicked;

        public void Init(HeroData data, bool isPlayer)
        {
            Data = data;
            IsPlayer = isPlayer;
            State = new HeroState(data);
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
