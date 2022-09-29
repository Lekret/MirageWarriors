using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;

namespace Heroes.BtActions
{
    public class MoveToTargetPosition : ActionBase
    {
        private readonly Hero _hero;

        public MoveToTargetPosition(Hero hero)
        {
            _hero = hero;
            Name = nameof(MoveToTargetPosition);
        }

        protected override TaskStatus OnUpdate()
        {
            var targetPosition = _hero.State.TargetPosition;
            if (!targetPosition.HasValue)
                return TaskStatus.Failure;
            
            var transform = _hero.transform;
            var newPosition = Vector2.MoveTowards(
                transform.position,
                targetPosition.Value,
                _hero.Data.Speed * Time.deltaTime);
            transform.position = newPosition;
            
            if (IsTargetPositionReached(newPosition, targetPosition.Value))
            {
                _hero.State.TargetPosition = null;
            }
            return TaskStatus.Success;
        }

        private static bool IsTargetPositionReached(Vector2 newPosition, Vector2 targetPosition)
        {
            var diff = targetPosition - newPosition;
            return diff.sqrMagnitude <= Vector2.kEpsilon;
        }
    }
}