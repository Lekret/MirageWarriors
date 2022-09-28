using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;

namespace Heroes.BtActions
{
    public class SubtractCooldown : ActionBase
    {
        private readonly Hero _hero;

        public SubtractCooldown(Hero hero)
        {
            _hero = hero;
            Name = nameof(SubtractCooldown);
        }

        protected override TaskStatus OnUpdate()
        {
            _hero.State.Cooldown = Mathf.Max(_hero.State.Cooldown - Time.deltaTime, 0);
            return TaskStatus.Success;
        }
    }
}