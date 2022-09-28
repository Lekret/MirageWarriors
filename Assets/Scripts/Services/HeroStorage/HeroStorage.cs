using System.Collections.Generic;
using Heroes;

namespace Services.HeroStorage
{
    public class HeroStorage : IHeroStorage
    {
        private readonly List<Hero> _heroes = new List<Hero>();
        private readonly List<Hero> _readBuffer = new List<Hero>();

        public void Add(Hero hero)
        {
            _heroes.Add(hero);
        }

        public void Remove(Hero hero)
        {
            _heroes.Remove(hero);
        }

        public IEnumerable<Hero> GetAll()
        {
            _readBuffer.Clear();
            _readBuffer.AddRange(_heroes);
            return _readBuffer;
        }
    }
}