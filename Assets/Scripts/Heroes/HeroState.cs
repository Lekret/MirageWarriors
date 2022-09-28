using StaticData;
using UnityEngine;

namespace Heroes
{
    public class HeroState
    {
        public bool IsPlayer { get; }
        public int Shield { get; private set; }
        public int Health { get; private set; }
        public float Cooldown { get; set; }
        public bool IsAggressive { get; set; }
        public Vector2? TargetPosition { get; set; }

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
        }
    }
}