using Services.BtFactory;
using Services.CameraProvider;
using Services.CoroutineRunner;
using Services.FoundMirageService;
using Services.HeroFactory;
using Services.HeroStorage;
using Services.MapProvider;
using Services.MirageService;
using Services.PointService;
using Services.SceneLoader;
using StateMachine;
using StaticData;
using Ui.Factory;
using UnityEngine;

namespace Infrastructure
{
    public class CompositionRoot : MonoBehaviour, ICoroutineRunner
    {
        public Configuration Configuration;
        private ISceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            var prefabs = Configuration.Prefabs;
            var gameSettings = Configuration.GameSettings;
            _sceneLoader = new SceneLoader(this);
            _stateMachine = new GameStateMachine();
            var cameraProvider = new MainCameraProvider();
            var mapProvider = new MapProvider();
            var heroStorage = new HeroStorage();
            var foundMirageService = new FoundMirageService();
            var mirageService = new MirageService(gameSettings);
            var pointService = new PointService(mapProvider);
            var btFactory = new BtFactory(
                mapProvider,
                heroStorage,
                pointService,
                mirageService,
                foundMirageService);
            var uiFactory = new UiFactory(
                prefabs,
                gameSettings,
                cameraProvider, 
                _stateMachine,
                mapProvider,
                mirageService);
            var heroFactory = new HeroFactory(prefabs, btFactory);
            var setupState = new SetupState(uiFactory);
            var gameState = new GameState(
                gameSettings, 
                heroStorage, 
                heroFactory, 
                mapProvider);
            var resultState = new ResultState();
            _stateMachine
                .AddState(setupState)
                .AddState(gameState)
                .AddState(resultState);
            
            _sceneLoader.Load("Game", () =>
            {
                _stateMachine.Enter<SetupState>();
            });
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}