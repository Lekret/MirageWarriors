using System.Collections.Generic;
using Heroes;
using UnityEngine;

namespace Services.PointService
{
    public interface IPointService
    {
        void GetPointsAroundHero(Hero hero, List<Vector2Int> buffer);
    }
}