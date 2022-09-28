using System.Collections.Generic;
using Heroes;
using Services.HeroFactory;
using Services.HeroStorage;
using Services.MapProvider;
using StaticData;

namespace StateMachine
{
    public class GameState : IEnterState<GameStateArgs>, IExitState, ITickState
    {
        private readonly GameSettings _gameSettings;
        private readonly IHeroStorage _heroStorage;
        private readonly IHeroFactory _heroFactory;
        private readonly IMapProvider _mapProvider;
        private int _heroSwitchCount;

        public GameState(
            GameSettings gameSettings,
            IHeroStorage heroStorage,
            IHeroFactory heroFactory,
            IMapProvider mapProvider)
        {
            _gameSettings = gameSettings;
            _heroStorage = heroStorage;
            _heroFactory = heroFactory;
            _mapProvider = mapProvider;
        }

        public void Enter(GameStateArgs args)
        {
            _heroSwitchCount = _gameSettings.HeroSwitchCount;
            _mapProvider.GetMap().Init(_gameSettings);
            SpawnHeroes(args.SpawnData);
        }
        
        public void Tick()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.Bt.Tick();
            }
        }

        public void Exit()
        {
            DisposeHeroes();
        }
        
        private void SpawnHeroes(IEnumerable<HeroSpawnData> spawnData)
        {
            foreach (var data in spawnData)
            {
                var hero = _heroFactory.CreateHero(data.Data, data.IsPlayer, data.Position);
                _heroStorage.Add(hero);
                hero.Died += OnHeroDied;
                if (hero.State.IsPlayer)
                    hero.Clicked += SwitchHero;
            }
        }

        private void DisposeHeroes()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                _heroStorage.Remove(hero);
                hero.Died -= OnHeroDied;
                if (hero.State.IsPlayer)
                    hero.Clicked -= SwitchHero;
            }
        }
        
        private void OnHeroDied(Hero hero)
        {
            hero.Died -= OnHeroDied;
            _heroStorage.Remove(hero);
        }
        
        private void SwitchHero(Hero hero)
        {
            if (_heroSwitchCount <= 0)
                return;
            hero.State.IsAggressive = !hero.State.IsAggressive;
            _heroSwitchCount--;
        }
    }
}