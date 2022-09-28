using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class RemoveTargetPosition : ActionBase
    {
        private readonly Hero _hero;

        public RemoveTargetPosition(Hero hero)
        {
            _hero = hero;
            Name = nameof(RemoveTargetPosition);
        }

        protected override TaskStatus OnUpdate()
        {
            _hero.State.TargetPosition = null;
            return TaskStatus.Success;
        }
    }
}