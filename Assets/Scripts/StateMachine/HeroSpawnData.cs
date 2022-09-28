using StaticData;
using UnityEngine;

namespace StateMachine
{
    public readonly struct HeroSpawnData
    {
        public readonly HeroData Data;
        public readonly Vector2 Position;
        public readonly bool IsPlayer;

        public HeroSpawnData(HeroData data, Vector2 position, bool isPlayer)
        {
            Data = data;
            Position = position;
            IsPlayer = isPlayer;
        }
    }
}