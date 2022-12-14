using System;
using StaticData;
using UnityEngine;

namespace Heroes
{
    public class HeroState
    {
        private bool _isAggressive;
        public bool IsPlayer { get; }
        public bool IsDead { get; set; }
        public int Shield { get; private set; }
        public int Health { get; private set; }
        public float Cooldown { get; set; }
        public bool IsAggressive
        {
            get => _isAggressive;
            set
            {
                _isAggressive = value;
                AggressionChanged?.Invoke(_isAggressive);
            }
        }

        public Vector2? TargetPosition { get; set; }
        public event Action<bool> AggressionChanged;
        public event Action HealthChanged;

        public HeroState(HeroData data, bool isPlayer)
        {
            Shield = data.Shield;
            Health = data.Health;
            IsPlayer = isPlayer;
        }

        public void ApplyDamage(int damage)
        {
            if (Shield >= damage)
            {
                Shield -= damage;
                damage = 0;
            }
            else
            {
                damage -= Shield;
                Shield = 0;
            }

            Health = Mathf.Max(Health - damage, 0);
            HealthChanged?.Invoke();
        }
    }
}