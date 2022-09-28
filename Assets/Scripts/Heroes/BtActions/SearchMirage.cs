using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.PointService;

namespace Heroes.BtActions
{
    public class SearchMirage : ActionBase
    {
        private readonly Hero _hero;
        private readonly IPointService _pointService;

        public SearchMirage(Hero hero)
        {
            _hero = hero;
            Name = nameof(SearchMirage);
        }

        protected override TaskStatus OnUpdate()
        {
            //TODO SEARCH
            return TaskStatus.Success;
        }
    }
}