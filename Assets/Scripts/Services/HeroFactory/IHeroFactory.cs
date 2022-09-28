using Heroes;
using StaticData;
using UnityEngine;

namespace Services.HeroFactory
{
    public interface IHeroFactory
    {
        Hero CreateHero(HeroData data, bool isPlayer, Vector2 position);
    }
}