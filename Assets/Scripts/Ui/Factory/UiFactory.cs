using System.Collections.Generic;
using Heroes;
using Services.CameraProvider;
using Services.MapProvider;
using Services.MirageService;
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
        private readonly IMirageService _mirageService;
        private Transform _uiRoot;

        public UiFactory(
            Prefabs prefabs, 
            GameSettings gameSettings,
            ICameraProvider cameraProvider, 
            IGameStateMachine gameStateMachine,
            IMapProvider mapProvider,
            IMirageService mirageService)
        {
            _prefabs = prefabs;
            _cameraProvider = cameraProvider;
            _gameStateMachine = gameStateMachine;
            _mapProvider = mapProvider;
            _mirageService = mirageService;
            _gameSettings = gameSettings;
        }

        public void CreateUiRoot()
        {
            _uiRoot = Object.Instantiate(_prefabs.UiRoot).transform;
        }

        public ProgressUi CreateProgress()
        {
            var progressUi = Object.Instantiate(_prefabs.ProgressUi, _uiRoot);
            progressUi.Init(_mirageService);
            return progressUi;
        }

        public HeroInfo CreateHeroInfo(IEnumerable<HeroPreview> previews)
        {
            var heroInfo = Object.Instantiate(_prefabs.HeroInfo, _uiRoot);
            heroInfo.Init(previews);
            return heroInfo;
        }

        public SetupUi CreateSetup()
        {
            var setupUi = Object.Instantiate(_prefabs.SetupUi, _uiRoot);
            setupUi.Init(_gameStateMachine, _mapProvider, _cameraProvider, _gameSettings);
            return setupUi;
        }
    }
}