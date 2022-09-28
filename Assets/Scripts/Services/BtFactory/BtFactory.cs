using CleverCrow.Fluid.BTs.Trees;
using Heroes;
using Heroes.BtActions;
using Services.MapProvider;

namespace Services.BtFactory
{
    public class BtFactory : IBtFactory
    {
        private readonly IMapProvider _mapProvider;

        public BtFactory(IMapProvider mapProvider)
        {
            _mapProvider = mapProvider;
        }

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
                    .AddNode(new IsInBattleState(hero))
                    .Selector()
                        .AddNode(new AttackEnemies(hero))
                        .Sequence()
                            .AddNode(new HasCooldown(hero))
                            .AddNode(new SubtractCooldown(hero))
                            .AddNode(new SetRandomTargetPosition(hero, _mapProvider))
                            .AddNode(new MoveToTargetPosition(hero))
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
                        .AddNode(new IsTargetPositionReached(hero))
                        .AddNode(new RemoveTargetPosition(hero))
                    .End()
                .End();
        }
    }
}