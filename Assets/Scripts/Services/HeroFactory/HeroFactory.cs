using Heroes;
using Services.BtFactory;
using StaticData;
using UnityEngine;

namespace Services.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly Prefabs _prefabs;
        private readonly IBtFactory _btFactory;

        public HeroFactory(Prefabs prefabs, IBtFactory btFactory)
        {
            _prefabs = prefabs;
            _btFactory = btFactory;
        }

        public Hero CreateHero(HeroData data, bool isPlayer, Vector2 position)
        {
            var hero = Object.Instantiate(_prefabs.Hero);
            hero.Init(data, isPlayer);
            hero.transform.position = position;
            var bt = _btFactory.Create(hero);
            hero.SetBt(bt);
            return hero;
        }
    }
}