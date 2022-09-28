using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class MoveToTargetPosition : ActionBase
    {
        private readonly Hero _hero;

        public MoveToTargetPosition(Hero hero)
        {
            _hero = hero;
        }

        protected override TaskStatus OnUpdate()
        {
            //TODO MOVE TO TARGET POSITION
            return TaskStatus.Success;
        }
    }
}