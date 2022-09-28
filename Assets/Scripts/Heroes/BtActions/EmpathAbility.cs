using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.HeroStorage;

namespace Heroes.BtActions
{
    public class EmpathAbility : ActionBase
    {
        private readonly Hero _hero;
        private readonly IHeroStorage _heroStorage;

        public EmpathAbility(Hero hero, IHeroStorage heroStorage)
        {
            _hero = hero;
            _heroStorage = heroStorage;
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
            foreach (var other in _heroStorage.GetAll())
            {
                if (other.State.IsPlayer == _hero.State.IsPlayer)
                    count++;
            }
            return count;
        }
    }
}