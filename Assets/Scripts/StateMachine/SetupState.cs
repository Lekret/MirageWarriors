using Ui;
using Ui.Factory;
using UnityEngine;

namespace StateMachine
{
    public class SetupState : IEnterState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private readonly GameStateMachine _gameStateMachine;
        private SetupUi _setupUi;

        public SetupState(GameStateMachine gameStateMachine, IUiFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
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

        private void OnStartPressed()
        {
            _gameStateMachine.Enter<GameState>();
        }
    }
}