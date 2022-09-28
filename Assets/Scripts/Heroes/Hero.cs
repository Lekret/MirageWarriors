using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Hero : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ActionArea _actionArea;
        [SerializeField] private SpriteRenderer _renderer;
        [Tooltip("Field is exposed for tree debugger")]
        [SerializeField] private BehaviorTree _bt;
        
        public HeroData Data { get; private set; }
        public HeroState State { get; private set; }
        public BehaviorTree Bt => _bt;
        public IEnumerable<Hero> NearestHeroes => _actionArea.NearestHeroes;
        public event Action<Hero> Clicked;
        
        public void Init(HeroData data, bool isPlayer)
        {
            Data = data;
            State = new HeroState(data, isPlayer);
            _actionArea.SetDiameter(data.ActionDiameter);
            _renderer.color = isPlayer ? Color.green : Color.red;
        }

        public void SetBt(BehaviorTree bt)
        {
            _bt = bt;
        }
        
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked?.Invoke(this);
    }
}
