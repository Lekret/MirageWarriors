using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.MapProvider;
using Services.PointService;
using UnityEngine;

namespace Heroes.BtActions
{
    public class SearchMirage : ActionBase
    {
        private readonly Hero _hero;
        private readonly IPointService _pointService;
        private readonly IMapProvider _mapProvider;
        private readonly List<Vector2Int> _pointsBuffer = new List<Vector2Int>();

        public SearchMirage(
            Hero hero, 
            IPointService pointService, 
            IMapProvider mapProvider)
        {
            _hero = hero;
            _pointService = pointService;
            _mapProvider = mapProvider;
            Name = nameof(SearchMirage);
        }
        
        protected override TaskStatus OnUpdate()
        {
            var map = _mapProvider.GetMap();
            _pointService.GetPointsAroundHero(_hero, _pointsBuffer);
            var searchLimit = _hero.Data.Search;
            var searchCount = 0;
            
            foreach (var point in _pointsBuffer)
            {
                if (searchCount >= searchLimit)
                    break;

                if (map.OpenCell(point))
                {
                    searchCount++;
                }
            }

            return searchCount > 0 ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}