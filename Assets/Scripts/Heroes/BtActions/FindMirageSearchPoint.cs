using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.MapProvider;

namespace Heroes.BtActions
{
    public class FindMirageSearchPoint : ActionBase
    {
        private readonly Hero _hero;
        private readonly IMapProvider _mapProvider;

        public FindMirageSearchPoint(Hero hero, IMapProvider mapProvider)
        {
            _hero = hero;
            _mapProvider = mapProvider;
            Name = nameof(FindMirageSearchPoint);
        }

        protected override TaskStatus OnUpdate()
        {
            var randomPoint = _mapProvider.GetMap().GetRandomPoint();
            _hero.State.TargetPosition = randomPoint;
            return TaskStatus.Success;
        }
    }
}