using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.MapProvider;
using UnityEngine;

namespace Heroes.BtActions
{
    public class SelectMirageTargetPosition : ActionBase
    {
        private readonly Hero _hero;
        private readonly IMapProvider _mapProvider;
        
        public SelectMirageTargetPosition(Hero hero, IMapProvider mapProvider)
        {
            _hero = hero;
            _mapProvider = mapProvider;
            Name = nameof(SelectMirageTargetPosition);
        }
        
        protected override TaskStatus OnUpdate()
        {
            var map = _mapProvider.GetMap();
            var miragePositions = map.MiragePositions;
            if (miragePositions.Count == 0)
                return TaskStatus.Failure;
            var closerMirage = FindCloserMirage(miragePositions);
            _hero.State.TargetPosition = closerMirage;
            return TaskStatus.Success;
        }

        private static Vector2 FindCloserMirage(IEnumerable<Vector2Int> miragePositions)
        {
            var closerPosition = new Vector2(float.MaxValue, float.MaxValue);
            var minSqrMag = 0f;
            foreach (var position in miragePositions)
            {
                var newSqrMag = Vector2.SqrMagnitude(closerPosition - position);
                if (newSqrMag < minSqrMag)
                {
                    minSqrMag = newSqrMag;
                    closerPosition = position;
                }
            }
            return closerPosition;
        }
    }
}