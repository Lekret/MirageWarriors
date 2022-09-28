using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Heroes.BtActions
{
    public class SearchMirage : ActionBase
    {
        private readonly Hero _hero;

        public SearchMirage(Hero hero)
        {
            _hero = hero;
            Name = nameof(SearchMirage);
        }

        protected override TaskStatus OnUpdate()
        {
            //TODO SEARCH
            return TaskStatus.Success;
        }
    }
}