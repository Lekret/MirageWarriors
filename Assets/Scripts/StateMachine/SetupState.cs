using System.Collections.Generic;
using Services.HeroFactory;
using Services.HeroStorage;
using UnityEngine;
using StaticData;
using Ui.Factory;
using Ui;

namespace StateMachine
{
    public class SetupState : IEnterState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private readonly IHeroFactory _heroFactory;
        private readonly IHeroStorage _heroStorage;
        private readonly GameSettings _gameSettings;
        private readonly List<Object> _uiControls = new List<Object>();
        private SetupUi _setupUi;
        private HeroInfo _heroInfo;

        public SetupState(
            IUiFactory uiFactory,
            IHeroFactory heroFactory,
            IHeroStorage heroStorage,
            GameSettings gameSettings)
        {
            _uiFactory = uiFactory;
            _heroFactory = heroFactory;
            _heroStorage = heroStorage;
            _gameSettings = gameSettings;
        }

        public void Enter()
        {
            SpawnHeroes();
            CreateUi();
        }
        
        public void Exit()
        {
            DeleteUi();
        }
        
        private void SpawnHeroes()
        {
            foreach (var data in _gameSettings.PlayerTeam)
            {
                var hero = _heroFactory.CreateHero(data, true);
                _heroStorage.Add(hero);
            }

            foreach (var data in _gameSettings.EnemyTeam)
            {
                var hero = _heroFactory.CreateHero(data, false);
                _heroStorage.Add(hero);
            }
        }

        private void CreateUi()
        {
            _uiFactory.CreateUiRoot();
            _uiControls.Add(_uiFactory.CreateSetup());
            _uiControls.Add(_uiFactory.CreateHeroInfo());
        }

        private void DeleteUi()
        {
            foreach (var control in _uiControls)
            {
                Object.Destroy(control);
            }
        }
    }
}