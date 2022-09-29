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
            return _mapProvider.GetMap().MiragePositions.Count > 0;
        }
    }
}