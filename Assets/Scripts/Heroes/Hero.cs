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
        public event Action<Hero> Died; 

        public void Init(HeroData data, bool isPlayer)
        {
            Data = data;
            State = new HeroState(data, isPlayer);
            _actionArea.SetDiameter(data.ActionDiameter);
            _renderer.color = isPlayer ? Color.green : Color.red;
            State.HealthChanged += OnHealthChanged;
            State.AggressionChanged += _actionArea.SetAggressive;
            _actionArea.SetAggressive(State.IsAggressive);
        }

        private void OnDestroy()
        {
            State.HealthChanged -= OnHealthChanged;
            State.AggressionChanged -= _actionArea.SetAggressive;
        }
        
        private void OnHealthChanged()
        {
            if (State.Health > 0 || State.IsDead) 
                return;
            State.IsDead = true;
            Died?.Invoke(this);
            Destroy(gameObject);
        }

        public void SetBt(BehaviorTree bt)
        {
            _bt = bt;
        }
        
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked?.Invoke(this);
    }
}
