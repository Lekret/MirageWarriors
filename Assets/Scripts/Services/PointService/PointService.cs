using System.Collections.Generic;
using Heroes;
using Services.MapProvider;
using UnityEngine;
using Utils;

namespace Services.PointService
{
    public class PointService : IPointService
    {
        private readonly IMapProvider _mapProvider;

        public PointService(IMapProvider mapProvider)
        {
            _mapProvider = mapProvider;
        }

        public void GetPointsAroundHero(Hero hero, List<Vector2Int> buffer)
        {
            var map = _mapProvider.GetMap();
            var radius = hero.Data.ActionDiameter / 2;
            var heroPos = hero.transform.position.ToVec2Int();

            var minX = heroPos.x - radius;
            var maxX = heroPos.x + radius;
            var minY = heroPos.y - radius;
            var maxY = heroPos.y + radius;

            for (var x = minX; x <= maxX; x += 1)
            {
                for (var y = minY; y <= maxY; y += 1)
                {
                    if (IsInCircle(new Vector2Int(x, y), heroPos, radius) && map.IsInBounds(x, y))
                    {
                        buffer.Add(new Vector2Int(x, y));
                    }
                }
            }
        }
        
        private static bool IsInCircle(Vector2 point, Vector2 circlePoint, float radius)
        {
            return (point - circlePoint).sqrMagnitude <= radius * radius;
        }
    }
}