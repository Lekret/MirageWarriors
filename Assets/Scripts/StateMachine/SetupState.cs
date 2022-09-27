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
        private readonly List<GameObject> _uiControls = new List<GameObject>();
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
            CreateSetupUi();
        }
        
        public void Exit()
        {
            DeleteSetupUi();
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

        private void CreateSetupUi()
        {
            _uiFactory.CreateUiRoot();
            _uiControls.Add(_uiFactory.CreateSetup().gameObject);
            _uiControls.Add(_uiFactory.CreateHeroInfo().gameObject);
        }

        private void DeleteSetupUi()
        {
            foreach (var control in _uiControls)
            {
                Object.Destroy(control);
            }
        }
    }
}