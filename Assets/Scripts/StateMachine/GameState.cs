using Heroes;
using Services.HeroStorage;
using StaticData;

namespace StateMachine
{
    public class GameState : IEnterState, IExitState, ITickState
    {
        private readonly IHeroStorage _heroStorage;
        private readonly GameSettings _gameSettings;
        private int _heroSwitchCount;

        public GameState(IHeroStorage heroStorage, GameSettings gameSettings)
        {
            _heroStorage = heroStorage;
            _gameSettings = gameSettings;
        }

        public void Enter()
        {
            _heroSwitchCount = _gameSettings.HeroSwitchCount;
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.PointerClicked += OnSwitchHero;
            }
        }

        public void Exit()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.PointerClicked -= OnSwitchHero;
            }
        }

        private void OnSwitchHero(Hero hero)
        {
            if (_heroSwitchCount == 0)
                return;
            hero.State.IsAggressive = !hero.State.IsAggressive;
            _heroSwitchCount--;
        }
        
        public void Tick()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.Bt.Tick();
            }
        }
    }
}