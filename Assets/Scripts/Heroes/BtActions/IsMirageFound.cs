using CleverCrow.Fluid.BTs.Tasks;
using Services.FoundMirageService;

namespace Heroes.BtActions
{
    public class IsMirageFound : ConditionBase
    {
        private readonly IFoundMirageService _foundMirageService;
        
        public IsMirageFound(IFoundMirageService foundMirageService)
        {
            _foundMirageService = foundMirageService;
            Name = nameof(IsMirageFound);
        }
        
        protected override bool OnUpdate()
        {
            return _foundMirageService.GetPositions().Count > 0;
        }
    }
}