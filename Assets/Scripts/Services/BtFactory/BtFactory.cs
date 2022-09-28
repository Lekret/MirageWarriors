using CleverCrow.Fluid.BTs.Trees;
using Heroes;

namespace Services.BtFactory
{
    public class BtFactory : IBtFactory
    {
        public BehaviorTree Create(Hero hero)
        {
            var builder = new BehaviorTreeBuilder(null);
            var bt = builder.Build();
            hero.SetBehaviorTree(bt);
            return bt;
        }
    }
}