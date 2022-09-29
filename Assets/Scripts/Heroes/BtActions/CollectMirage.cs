using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.MapProvider;
using Services.MirageService;
using Services.PointService;
using UnityEngine;

namespace Heroes.BtActions
{
    public class CollectMirage : ActionBase
    {
        private readonly Hero _hero;
        private readonly IPointService _pointService;
        private readonly IMapProvider _mapProvider;
        private readonly IMirageService _mirageService;
        private readonly List<Vector2Int> _pointsBuffer = new List<Vector2Int>();

        public CollectMirage(
            Hero hero, 
            IPointService pointService, 
            IMapProvider mapProvider,
            IMirageService mirageService)
        {
            _hero = hero;
            _pointService = pointService;
            _mapProvider = mapProvider;
            _mirageService = mirageService;
            Name = nameof(CollectMirage);
        }
        
        protected override TaskStatus OnUpdate()
        {
            var map = _mapProvider.GetMap();
            _pointService.GetPointsAroundHero(_hero, _pointsBuffer);
            var collectLimit = _hero.Data.Collection;
            var collectedMirage = 0;
            
            foreach (var point in _pointsBuffer)
            {
                if (collectedMirage >= collectLimit)
                    break;
                ref var cell = ref map[point.x, point.y];
                if (cell.IsOpen)
                {
                    collectedMirage += cell.Mirage;
                    cell.Mirage = 0;
                }
            }

            if (collectedMirage > 0)
            {
                _mirageService.AddMirage(_hero, collectedMirage);
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}