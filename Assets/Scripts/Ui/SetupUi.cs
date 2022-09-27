using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class SetupUi : MonoBehaviour
    {
        [SerializeField] private Button _start;

        private IGameStateMachine _gameStateMachine;

        public void Init(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _start.onClick.AddListener(BeginBattle);
        }

        private void OnDestroy()
        {
            _start.onClick.RemoveListener(BeginBattle);
        }
        
        private void BeginBattle()
        {
            _gameStateMachine.Enter<GameState>();
        }
    }
}