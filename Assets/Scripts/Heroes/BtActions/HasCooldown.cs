using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class HasCooldown : ConditionBase
    {
        private readonly Hero _hero;

        public HasCooldown(Hero hero)
        {
            _hero = hero;
            Name = nameof(HasCooldown);
        }

        protected override bool OnUpdate()
        {
            return _hero.State.Cooldown > 0;
        }
    }
}