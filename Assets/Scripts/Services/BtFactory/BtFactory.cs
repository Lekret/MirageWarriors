using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Heroes;
using Heroes.BtActions;

namespace Services.BtFactory
{
    public class BtFactory : IBtFactory
    {
        public BehaviorTree Create(Hero hero)
        {
            var builder = new BehaviorTreeBuilder(hero.gameObject);
            builder.Selector();
            AddBattle(builder, hero);
            AddPeaceful(builder, hero);
            builder.End();
            var bt = builder.Build();
            hero.SetBehaviorTree(bt);
            return bt;
        }

        private void AddBattle(BehaviorTreeBuilder builder, Hero hero)
        {
            builder
                .Sequence()
                    .AddNode(new ShouldAttack(hero))
                    .Selector()
                        .Sequence()
                            .AddNode(new HasEnemiesInRange(hero))
                            .AddNode(new AttackEnemies(hero))
                        .End()
                        .Sequence()
                            .AddNode(new HasCooldown(hero))
                            .AddNode(new SubtractCooldown(hero))
                            .AddNode(new MoveToRandomDirection(hero))
                        .End()
                        .AddNode(new SetHeroPeaceful(hero))
                    .End()
                .End();
        }

        private void AddPeaceful(BehaviorTreeBuilder builder, Hero hero)
        {
            builder
                .Selector()
                    .Sequence()
                        .AddNode(new IsMirageFound())
                        .Selector()
                            .AddNode(new CollectMirage())
                            .AddNode(new MoveToMirage())
                        .End()
                    .End()
                    .Sequence()
                        .AddNode(new MoveToTargetPosition(hero))
                        .AddNode(new IsTargetPositionReached(hero))
                        .AddNode(new RemoveTargetPosition(hero))
                    .End()
                    .AddNode(new SearchMirage(hero))
                    .Sequence()
                        .AddNode(new FindMirageSearchArea(hero))
                        .AddNode(new MoveToTargetPosition(hero))
                    .End()
                .End();
        }
    }
}