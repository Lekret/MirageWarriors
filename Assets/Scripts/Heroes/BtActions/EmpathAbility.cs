using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.HeroStorage;

namespace Heroes.BtActions
{
    public class EmpathAbility : ActionBase
    {
        private readonly Hero _hero;
        private readonly IHeroStorage _heroStorage;
        private readonly List<Hero> _heroBuffer = new List<Hero>();

        public EmpathAbility(Hero hero, IHeroStorage heroStorage)
        {
            _hero = hero;
            _heroStorage = heroStorage;
            Name = nameof(EmpathAbility);
        }

        protected override TaskStatus OnUpdate()
        {
            if (_hero.Data.Character == Character.Empath)
            {
                var aggressiveAllyCount = GetAggressiveAllyCount();
                if (aggressiveAllyCount >= 3)
                    _hero.State.IsAggressive = true;
            }
            return TaskStatus.Success;
        }

        private int GetAggressiveAllyCount()
        {
            var count = 0;
            _heroStorage.GetAll(_heroBuffer);
            foreach (var other in _heroBuffer)
            {
                if (other.State.IsPlayer == _hero.State.IsPlayer)
                    count++;
            }
            return count;
        }
    }
}