using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Services.FoundMirageService;
using UnityEngine;

namespace Heroes.BtActions
{
    public class SelectMirageTargetPosition : ActionBase
    {
        private readonly Hero _hero;
        private readonly IFoundMirageService _foundMirageService;
        
        public SelectMirageTargetPosition(Hero hero, IFoundMirageService foundMirageService)
        {
            _hero = hero;
            _foundMirageService = foundMirageService;
            Name = nameof(SelectMirageTargetPosition);
        }
        
        protected override TaskStatus OnUpdate()
        {
            var closerMirage = FindCloserMirage();
            _hero.State.TargetPosition = closerMirage;
            return TaskStatus.Success;
        }

        private Vector2 FindCloserMirage()
        {
            var closerPosition = new Vector2(float.MaxValue, float.MaxValue);
            var minSqrMag = 0f;
            foreach (var position in _foundMirageService.GetPositions())
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