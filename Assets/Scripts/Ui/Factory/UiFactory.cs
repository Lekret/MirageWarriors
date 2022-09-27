using Services.CameraProvider;
using Services.HeroStorage;
using StateMachine;
using StaticData;
using UnityEngine;

namespace Ui.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly Prefabs _prefabs;
        private readonly ICameraProvider _cameraProvider;
        private readonly IHeroStorage _heroStorage;
        private readonly IGameStateMachine _gameStateMachine;
        private Transform _uiRoot;

        public UiFactory(
            Prefabs prefabs, 
            ICameraProvider cameraProvider, 
            IHeroStorage heroStorage, 
            IGameStateMachine gameStateMachine)
        {
            _prefabs = prefabs;
            _cameraProvider = cameraProvider;
            _heroStorage = heroStorage;
            _gameStateMachine = gameStateMachine;
        }

        public void CreateUiRoot()
        {
            _uiRoot = Object.Instantiate(_prefabs.UiRoot).transform;
            var canvas = _uiRoot.GetComponent<Canvas>();
            canvas.worldCamera = _cameraProvider.GetCamera();
        }

        public HeroInfo CreateHeroInfo()
        {
            var heroInfo = Object.Instantiate(_prefabs.HeroInfo, _uiRoot);
            heroInfo.Init(_cameraProvider, _heroStorage);
            return heroInfo;
        }

        public SetupUi CreateSetup()
        {
            var setupUi = Object.Instantiate(_prefabs.SetupUi, _uiRoot);
            setupUi.Init(_gameStateMachine);
            return setupUi;
        }
    }
}