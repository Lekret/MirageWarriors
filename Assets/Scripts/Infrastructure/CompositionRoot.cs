using Services.SceneLoader;
using StateMachine;
using StaticData;
using Ui.Factory;
using UnityEngine;

namespace Infrastructure
{
    public class CompositionRoot : MonoBehaviour
    {
        public Configuration Configuration;
        private ISceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            var uiFactory = new UiFactory(Configuration.Prefabs);
            _sceneLoader = new SceneLoader();
            _stateMachine = new GameStateMachine()
                .AddState(new SetupState(uiFactory))
                .AddState(new GameState())
                .AddState(new ResultState());
            _sceneLoader.Load("Game");
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}