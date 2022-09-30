using System.Collections.Generic;
using Heroes;

namespace Services.HeroStorage
{
    public interface IHeroStorage
    {
        void Add(Hero hero);
        void Remove(Hero hero);
        List<Hero> GetAll();
        List<Hero> GetAll(List<Hero> heroes);
    }
}