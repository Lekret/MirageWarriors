using CleverCrow.Fluid.BTs.Trees;
using Heroes;
using Heroes.BtActions;
using Services.HeroStorage;
using Services.MapProvider;

namespace Services.BtFactory
{
    public class BtFactory : IBtFactory
    {
        private readonly IMapProvider _mapProvider;
        private readonly IHeroStorage _heroStorage;

        public BtFactory(IMapProvider mapProvider, IHeroStorage heroStorage)
        {
            _mapProvider = mapProvider;
            _heroStorage = heroStorage;
        }

        public BehaviorTree Create(Hero hero)
        {
            var builder = new BehaviorTreeBuilder(hero.gameObject);
            builder.Selector();
            AddBattle(builder, hero);
            AddPeaceful(builder, hero);
            builder.End();
            var bt = builder.Build();
            hero.SetBt(bt);
            return bt;
        }

        private void AddBattle(BehaviorTreeBuilder builder, Hero hero)
        {
            builder
                .Sequence()
                    .AddNode(new EmpathAbility(hero, _heroStorage))
                    .AddNode(new IsInBattleState(hero))
                    .Selector()
                        .AddNode(new AttackEnemies(hero))
                        .Sequence()
                            .AddNode(new HasCooldown(hero))
                            .AddNode(new SubtractCooldown(hero))
                            .Selector()
                                .AddNode(new MoveToTargetPosition(hero))
                                .AddNode(new SetRandomTargetPosition(hero, _mapProvider))
                            .End()
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