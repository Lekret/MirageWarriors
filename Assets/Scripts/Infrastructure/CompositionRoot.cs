using Infrastructure.StateMachine;
using Services.SceneLoader;
using UnityEngine;

namespace Infrastructure
{
    public class CompositionRoot : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            _sceneLoader = new SceneLoader();
            _stateMachine = new GameStateMachine()
                .AddState(new SetupState())
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