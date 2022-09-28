using StaticData;
using UnityEngine;

namespace Heroes
{
    public class HeroState
    {
        public int Shield;
        public int Health;
        public float Cooldown;
        public bool IsAggressive;
        public Vector2? TargetPosition;

        public HeroState(HeroData data)
        {
            Shield = data.Shield;
            Health = data.Health;
        }
    }
}