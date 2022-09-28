using CleverCrow.Fluid.BTs.Trees;
using Heroes;

namespace Services.BtFactory
{
    public interface IBtFactory
    {
        BehaviorTree Create(Hero hero);
    }
}