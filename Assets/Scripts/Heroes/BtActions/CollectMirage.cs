using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class CollectMirage : ActionBase
    {
        public CollectMirage()
        {
            Name = nameof(CollectMirage);
        }
        
        protected override TaskStatus OnUpdate()
        {
            //TODO COLLECT MIRAGE
            return TaskStatus.Success;
        }
    }
}