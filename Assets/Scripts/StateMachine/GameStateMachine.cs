using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _current;

        public void Update()
        {
            if (_current is ITickState tickState)
            {
                tickState.Tick();
            }
        }
        
        public GameStateMachine AddState<T>(T state) where T : IState
        {
            _states.Add(typeof(T), state);
            return this;
        }

        public void Enter<T>() where T : IState
        {
            var state = ChangeState<T>();
            if (state is IEnterState enterState)
            {
                enterState.Enter();
            }
        }

        private T ChangeState<T>() where T : IState
        {
            if (_current is IExitState exitState)
            {
                exitState.Exit();
            }
            var newState = (T) _states[typeof(T)];
            _current = newState;
            return newState;
        }
    }
}