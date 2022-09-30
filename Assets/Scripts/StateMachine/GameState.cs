using System.Collections.Generic;
using Heroes;
using Services.HeroFactory;
using Services.HeroStorage;
using Services.MapProvider;
using Services.MirageService;
using Services.Victory;
using StaticData;
using Ui.Factory;

namespace StateMachine
{
    public class GameState : IEnterState<GameStateArgs>, IExitState, ITickState
    {
        private readonly GameSettings _gameSettings;
        private readonly IHeroStorage _heroStorage;
        private readonly IHeroFactory _heroFactory;
        private readonly IMapProvider _mapProvider;
        private readonly IUiFactory _uiFactory;
        private readonly IVictoryService _victoryService;
        private readonly IMirageService _mirageService;
        private int _heroSwitchCount;

        public GameState(
            GameSettings gameSettings,
            IHeroStorage heroStorage,
            IHeroFactory heroFactory,
            IMapProvider mapProvider,
            IUiFactory uiFactory, 
            IVictoryService victoryService, 
            IMirageService mirageService)
        {
            _gameSettings = gameSettings;
            _heroStorage = heroStorage;
            _heroFactory = heroFactory;
            _mapProvider = mapProvider;
            _uiFactory = uiFactory;
            _victoryService = victoryService;
            _mirageService = mirageService;
        }

        public void Enter(GameStateArgs args)
        {
            _heroSwitchCount = _gameSettings.HeroSwitchCount;
            _mapProvider.GetMap().Init(_gameSettings);
            SpawnHeroes(args.SpawnData);
            _uiFactory.CreateProgress();
            _mirageService.PlayerMirageChanged += OnPlayerMirageChanged;
            _mirageService.EnemyMirageChanged += OnEnemyMirageChanged;
        }

        public void Exit()
        {
            DisposeHeroes();
            _mirageService.PlayerMirageChanged -= OnPlayerMirageChanged;
            _mirageService.EnemyMirageChanged -= OnEnemyMirageChanged;
        }
        
        public void Tick()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.Bt.Tick();
            }
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
            CheckVictoryByHeroCount();
        }
        
        private void SwitchHero(Hero hero)
        {
            if (_heroSwitchCount <= 0)
                return;
            hero.State.IsAggressive = !hero.State.IsAggressive;
            hero.State.Cooldown = hero.Data.Cooldown;
            _heroSwitchCount--;
        }

        private void CheckVictoryByHeroCount()
        {
            var heroes = _heroStorage.GetAll();
            var hasPlayer = false;
            var hasEnemy = false;
            foreach (var hero in heroes)
            {
                if (hero.State.IsPlayer)
                    hasPlayer = true;
                else
                    hasEnemy = true;
            }
            if (hasEnemy && !hasPlayer)
                _victoryService.TriggerEnemy();
            if (hasPlayer && !hasEnemy)
                _victoryService.TriggerPlayer();
        }

        private void OnPlayerMirageChanged(int mirage)
        {
            if (IsMirageAboveHalf(mirage))
                _victoryService.TriggerPlayer();
        }
        
        private void OnEnemyMirageChanged(int mirage)
        {
            if (IsMirageAboveHalf(mirage))
                _victoryService.TriggerEnemy();
        }

        private bool IsMirageAboveHalf(int mirage)
        {
            return mirage > _gameSettings.MirageCount / 2f;
        }
    }
}