using CleverCrow.Fluid.BTs.Tasks;
using Services.MapProvider;

namespace Heroes.BtActions
{
    public class IsMirageFound : ConditionBase
    {
        private readonly IMapProvider _mapProvider;
        
        public IsMirageFound(IMapProvider mapProvider)
        {
            _mapProvider = mapProvider;
            Name = nameof(IsMirageFound);
        }
        
        protected override bool OnUpdate()
        {
            var map = _mapProvider.GetMap();
            
            return false;
        }
    }
}