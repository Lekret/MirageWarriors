using Heroes;
using StaticData;
using UnityEngine;

namespace Services.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly Prefabs _prefabs;

        public HeroFactory(Prefabs prefabs)
        {
            _prefabs = prefabs;
        }

        public Hero CreateHero(HeroData data)
        {
            var hero = Object.Instantiate(_prefabs.Hero);
            return hero;
        }
    }
}