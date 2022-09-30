using System.Collections.Generic;
using System.Linq;
using Heroes;

namespace Services.HeroStorage
{
    public class HeroStorage : IHeroStorage
    {
        private readonly List<Hero> _heroes = new List<Hero>();

        public void Add(Hero hero)
        {
            _heroes.Add(hero);
        }

        public void Remove(Hero hero)
        {
            _heroes.Remove(hero);
        }

        public List<Hero> GetAll()
        {
            return _heroes.ToList();
        }

        public List<Hero> GetAll(List<Hero> heroes)
        {
            heroes.Clear();
            heroes.AddRange(_heroes);
            return heroes;
        }
    }
}