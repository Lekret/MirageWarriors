using Ui.Factory;
using Ui;
using UnityEngine;

namespace StateMachine
{
    public class SetupState : IEnterState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private readonly IGameStateMachine _gameStateMachine;
        private SetupUi _setupUi;
        private HeroInfo _heroInfo;

        public SetupState(
            IGameStateMachine gameStateMachine, 
            IUiFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _uiFactory.CreateUiRoot();
            _setupUi = _uiFactory.CreateSetup();
            _heroInfo = _uiFactory.CreateHeroInfo();
            _setupUi.StartPressed += OnStartPressed;
        }
        
        public void Exit()
        {
            _setupUi.StartPressed -= OnStartPressed;
        }

        private void OnStartPressed()
        {
            Object.Destroy(_setupUi);
            Object.Destroy(_heroInfo);
            _gameStateMachine.Enter<GameState>();
        }
    }
}