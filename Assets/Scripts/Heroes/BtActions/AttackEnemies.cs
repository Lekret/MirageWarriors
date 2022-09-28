using System.Collections.Generic;
using System.Linq;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class AttackEnemies : ActionBase
    {
        private readonly Hero _hero;
        private readonly List<Hero> _attackBuffer = new List<Hero>();

        public AttackEnemies(Hero hero)
        {
            _hero = hero;
        }

        protected override TaskStatus OnUpdate()
        {
            if (!_hero.HasAggressiveEnemiesNear()) 
                return TaskStatus.Failure;
            
            var enemiesToAttack = GetEnemiesToAttack();
            ApplyDamage(enemiesToAttack, _hero.Data.Damage);
            return TaskStatus.Success;
        }

        private List<Hero> GetEnemiesToAttack()
        {
            _attackBuffer.Clear();
            foreach (var other in _hero.NearestHeroes)
            {
                if (other.State.IsPlayer == _hero.State.IsPlayer)
                    continue;
                _attackBuffer.Add(other);
            }
            return _attackBuffer;
        }

        private static void ApplyDamage(List<Hero> heroes, int damage)
        {
            damage /= heroes.Count;
            foreach (var other in heroes)
            {
                other.State.ApplyDamage(damage);
            }
        }
    }
}