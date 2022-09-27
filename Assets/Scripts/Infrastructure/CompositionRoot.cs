using System;
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
            var uiFactory = new UiFactory(Configuration.Prefabs);
            _sceneLoader = new SceneLoader(this);
            _stateMachine = new GameStateMachine()
                .AddState(new SetupState(uiFactory))
                .AddState(new GameState())
                .AddState(new ResultState());
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