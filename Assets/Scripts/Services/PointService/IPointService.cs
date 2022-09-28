using System.Collections.Generic;
using Heroes;
using UnityEngine;

namespace Services.PointService
{
    public interface IPointService
    {
        void GetPointsInDiameter(Hero hero, List<Vector2Int> buffer);
    }
}