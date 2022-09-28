using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class IsMirageFound : ConditionBase
    {
        public IsMirageFound()
        {
            Name = nameof(IsMirageFound);
        }
        
        protected override bool OnUpdate()
        {
            
            return false;
        }
    }
}