using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class IsInBattleState : ConditionBase
    {
        private readonly Hero _hero;

        public IsInBattleState(Hero hero)
        {
            _hero = hero;
        }

        protected override bool OnUpdate()
        {
            return _hero.State.IsAggressive || _hero.HasAggressiveEnemiesNear();
        }
    }
}