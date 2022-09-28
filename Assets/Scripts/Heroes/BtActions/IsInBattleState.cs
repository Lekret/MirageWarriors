using CleverCrow.Fluid.BTs.Tasks;

namespace Heroes.BtActions
{
    public class IsInBattleState : ConditionBase
    {
        private readonly Hero _hero;

        public IsInBattleState(Hero hero)
        {
            _hero = hero;
        }

        protected override bool OnUpdate()
        {
            return _hero.State.IsAggressive ||
                   _hero.Data.Character != Character.Pacifist && 
                   HasAggressiveEnemiesNear();
        }

        private bool HasAggressiveEnemiesNear()
        {
            foreach (var other in _hero.NearestHeroes)
            {
                if (other.State.IsPlayer == _hero.State.IsPlayer) 
                    continue;
                if (other.State.IsAggressive) 
                    return true;
            }
            return false;
        }
    }
}