using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class FindMirageSearchArea : ActionBase
    {
        private readonly Hero _hero;

        public FindMirageSearchArea(Hero hero)
        {
            _hero = hero;
        }

        protected override TaskStatus OnUpdate()
        {
            //todo find search area
            return TaskStatus.Success;
        }
    }
}