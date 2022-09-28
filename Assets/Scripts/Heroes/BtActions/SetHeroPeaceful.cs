using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class SetHeroPeaceful : ActionBase
    {
        private readonly Hero _hero;

        public SetHeroPeaceful(Hero hero)
        {
            _hero = hero;
        }

        protected override TaskStatus OnUpdate()
        {
            _hero.State.IsAggressive = false;
            return TaskStatus.Success;
        }
    }
}