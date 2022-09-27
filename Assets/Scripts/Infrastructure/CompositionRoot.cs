﻿using Services.CameraProvider;
using Services.CoroutineRunner;
using Services.HeroFactory;
using Services.HeroStorage;
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
            var heroStorage = new HeroStorage();
            var uiFactory = new UiFactory(
                prefabs,
                cameraProvider, 
                heroStorage, 
                _stateMachine);
            var heroFactory = new HeroFactory(prefabs);
            var setupState = new SetupState(
                uiFactory,
                heroFactory,
                heroStorage,
                gameSettings);
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