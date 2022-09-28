using System.Collections.Generic;
using Ui;
using Ui.Factory;
using UnityEngine;

namespace StateMachine
{
    public class SetupState : IEnterState, IExitState
    {
        private readonly IUiFactory _uiFactory;
        private readonly List<GameObject> _uiControls = new List<GameObject>();
        private SetupUi _setupUi;
        private HeroInfo _heroInfo;

        public SetupState(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            CreateSetupUi();
        }
        
        public void Exit()
        {
            DeleteSetupUi();
        }
        
        private void CreateSetupUi()
        {
            _uiFactory.CreateUiRoot();
            var setupUi = _uiFactory.CreateSetup();
            _uiControls.Add(setupUi.gameObject);
            var heroInfo = _uiFactory.CreateHeroInfo(setupUi.GetPreviews());
            _uiControls.Add(heroInfo.gameObject);
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