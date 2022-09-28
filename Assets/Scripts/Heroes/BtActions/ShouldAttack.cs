using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class ShouldAttack : ConditionBase
    {
        private readonly Hero _hero;

        public ShouldAttack(Hero hero)
        {
            _hero = hero;
        }

        protected override bool OnUpdate()
        {
            return _hero.State.IsAggressive || HasAggressiveEnemiesInArea();
        }

        private bool HasAggressiveEnemiesInArea()
        {
            //TODO SHOULD FIGHT
            return false;
        }
    }
}