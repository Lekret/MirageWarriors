using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class HasEnemiesInRange : ConditionBase
    {
        private readonly Hero _hero;

        public HasEnemiesInRange(Hero hero)
        {
            _hero = hero;
        }

        protected override bool OnUpdate()
        {
            // TODO IN RANGE
            return true;
        }
    }
}