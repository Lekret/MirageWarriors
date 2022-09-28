using CleverCrow.Fluid.BTs.Trees;
using Heroes;
using Heroes.BtActions;
using Services.HeroStorage;
using Services.MapProvider;
using Services.PointService;

namespace Services.BtFactory
{
    public class BtFactory : IBtFactory
    {
        private readonly IMapProvider _mapProvider;
        private readonly IHeroStorage _heroStorage;
        private readonly IPointService _pointService;

        public BtFactory(
            IMapProvider mapProvider,
            IHeroStorage heroStorage, 
            IPointService pointService)
        {
            _mapProvider = mapProvider;
            _heroStorage = heroStorage;
            _pointService = pointService;
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
                        .AddNode(new IsMirageFound(_mapProvider))
                        .Selector()
                            .AddNode(new CollectMirage(hero, _pointService, _mapProvider))
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
                        .AddNode(new FindMirageSearchPoint(hero, _mapProvider))
                        .AddNode(new MoveToTargetPosition(hero))
                        .AddNode(new IsTargetPositionReached(hero))
                        .AddNode(new RemoveTargetPosition(hero))
                    .End()
                .End();
        }
    }
}