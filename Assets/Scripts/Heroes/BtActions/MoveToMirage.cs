using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class MoveToMirage : ActionBase
    {
        public MoveToMirage()
        {
            Name = nameof(MoveToMirage);
        }
        
        protected override TaskStatus OnUpdate()
        {
            //TODO MOVE TO MIRAGE
            return TaskStatus.Success;
        }
    }
}