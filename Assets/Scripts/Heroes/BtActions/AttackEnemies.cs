using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class AttackEnemies : ActionBase
    {
        private readonly Hero _hero;

        public AttackEnemies(Hero hero)
        {
            _hero = hero;
        }

        protected override TaskStatus OnUpdate()
        {
            // TODO ATTACK
            return TaskStatus.Success;
        }
    }
}