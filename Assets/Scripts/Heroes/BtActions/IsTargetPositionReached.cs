using CleverCrow.Fluid.BTs.Tasks;
using UnityEngine;

namespace Heroes.BtActions
{
    public class IsTargetPositionReached : ConditionBase
    {
        private readonly Hero _hero;

        public IsTargetPositionReached(Hero hero)
        {
            _hero = hero;
        }

        protected override bool OnUpdate()
        {
            var targetPosition = _hero.State.TargetPosition;
            if (targetPosition.HasValue)
            {
                var diff = targetPosition.Value - (Vector2) _hero.transform.position;
                return diff.sqrMagnitude <= Vector2.kEpsilon;
            }
            return true;
        }
    }
}