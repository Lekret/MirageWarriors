using Heroes;
using Services.HeroRaycaster;
using Ui;
using Ui.Factory;
using UnityEngine;

namespace StateMachine
{
    public class SetupState : IEnterState, ITickState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroRaycaster _heroRaycaster;
        private SetupUi _setupUi;

        public SetupState(
            IGameStateMachine gameStateMachine, 
            IUiFactory uiFactory,
            IHeroRaycaster heroRaycaster)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _heroRaycaster = heroRaycaster;
        }

        public void Enter()
        {
            _uiFactory.CreateUiRoot();
            _setupUi = _uiFactory.CreateSetupUi();
            _setupUi.StartPressed += OnStartPressed;
        }
        
        public void Exit()
        {
            _setupUi.StartPressed -= OnStartPressed;
        }

        public void Tick()
        {
            if (_heroRaycaster.TryRaycast(out var hero))
            {
                Debug.LogError("Hero found!");
            }
        }
        
        private void OnStartPressed()
        {
            _gameStateMachine.Enter<GameState>();
        }
    }
}