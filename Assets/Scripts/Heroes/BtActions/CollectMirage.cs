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

        public CollectMirage(Hero hero, IPointService pointService, IMapProvider mapProvider)
        {
            _hero = hero;
            _pointService = pointService;
            _mapProvider = mapProvider;
            Name = nameof(CollectMirage);
        }
        
        protected override TaskStatus OnUpdate()
        {
            var map = _mapProvider.GetMap();
            _pointService.GetPointsAroundHero(_hero, _pointsBuffer);
            var collectLimit = _hero.Data.Collection;
            var collectedCount = 0;
            var collectedMirage = 0;
            
            foreach (var point in _pointsBuffer)
            {
                if (collectedCount >= collectLimit)
                    break;
                var cellData = map[point.x, point.y];
                if (cellData.IsOpen)
                {
                    collectedCount++;
                    collectedMirage += cellData.Mirage;
                    cellData.Mirage = 0;
                    map[point.x, point.y] = cellData;
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