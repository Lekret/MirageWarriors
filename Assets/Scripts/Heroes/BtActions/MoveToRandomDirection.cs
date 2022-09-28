using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class MoveToRandomDirection : ActionBase
    {
        private readonly Hero _hero;

        public MoveToRandomDirection(Hero hero)
        {
            _hero = hero;
        }
        
        protected override TaskStatus OnUpdate()
        {
            // TODO RANDOM DIRECTION WHEN COOLDOWN
            return TaskStatus.Success;
        }
    }
}