using System.Collections.Generic;
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
            Name = nameof(AttackEnemies);
        }

        protected override TaskStatus OnUpdate()
        {
            var enemiesToAttack = GetEnemiesToAttack();
            if (enemiesToAttack.Count == 0) 
                return TaskStatus.Failure;
            
            ApplyDamage(enemiesToAttack, _hero.Data.Damage);
            _hero.State.Cooldown = _hero.Data.Cooldown;
            _hero.State.IsAggressive = true;
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