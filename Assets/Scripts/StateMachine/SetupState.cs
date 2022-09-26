using Ui;
using Ui.Factory;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class SetupState : IEnterState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private SetupUi _setupUi;

        public SetupState(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _setupUi = _uiFactory.CreateSetupUi();
        }

        public void Exit()
        {
            Object.Destroy(_setupUi);
        }
    }
}