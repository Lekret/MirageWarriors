using Services.CameraProvider;
using Services.CoroutineRunner;
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
            _sceneLoader = new SceneLoader(this);
            _stateMachine = new GameStateMachine();
            var cameraProvider = new MainCameraProvider();
            var uiFactory = new UiFactory(Configuration.Prefabs, cameraProvider);
            var setupState = new SetupState(_stateMachine, uiFactory);
            var gameState = new GameState();
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