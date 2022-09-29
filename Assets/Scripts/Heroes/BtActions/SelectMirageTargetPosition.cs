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
            var closerMirage = FindClosestMirage(miragePositions, _hero.transform.position);
            _hero.State.TargetPosition = closerMirage;
            return TaskStatus.Success;
        }

        private static Vector2 FindClosestMirage(IEnumerable<Vector2Int> miragePositions, Vector2 heroPosition)
        {
            var closerPosition = new Vector2(float.MaxValue, float.MaxValue);
            var minSqrMag = float.MaxValue;
            foreach (var position in miragePositions)
            {
                var newSqrMag = Vector2.SqrMagnitude(position - heroPosition);
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