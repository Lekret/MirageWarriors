using StaticData;
using UnityEngine;

namespace Heroes
{
    public class HeroState
    {
        public readonly bool IsPlayer;
        public int Shield;
        public int Health;
        public float Cooldown;
        public bool IsAggressive;
        public Vector2? TargetPosition;

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