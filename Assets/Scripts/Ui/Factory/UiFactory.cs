using System.Collections.Generic;
using Heroes;
using Services.CameraProvider;
using Services.MapProvider;
using StateMachine;
using StaticData;
using UnityEngine;

namespace Ui.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly Prefabs _prefabs;
        private readonly GameSettings _gameSettings;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IMapProvider _mapProvider;
        private Transform _uiRoot;

        public UiFactory(
            Prefabs prefabs, 
            GameSettings gameSettings,
            ICameraProvider cameraProvider, 
            IGameStateMachine gameStateMachine,
            IMapProvider mapProvider)
        {
            _prefabs = prefabs;
            _cameraProvider = cameraProvider;
            _gameStateMachine = gameStateMachine;
            _mapProvider = mapProvider;
            _gameSettings = gameSettings;
        }

        public void CreateUiRoot()
        {
            _uiRoot = Object.Instantiate(_prefabs.UiRoot).transform;
            var canvas = _uiRoot.GetComponent<Canvas>();
            canvas.worldCamera = _cameraProvider.GetCamera();
        }

        public HeroInfo CreateHeroInfo(IEnumerable<HeroPreview> previews)
        {
            var heroInfo = Object.Instantiate(_prefabs.HeroInfo, _uiRoot);
            heroInfo.Init(_cameraProvider, previews);
            return heroInfo;
        }

        public SetupUi CreateSetup()
        {
            var setupUi = Object.Instantiate(_prefabs.SetupUi, _uiRoot);
            setupUi.Init(_gameStateMachine, _mapProvider, _gameSettings);
            return setupUi;
        }
    }
}