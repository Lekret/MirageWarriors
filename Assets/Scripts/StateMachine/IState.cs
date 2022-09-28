namespace StateMachine
{
    public interface IState
    {
        
    }

    public interface IEnterState : IState
    {
        void Enter();
    }

    public interface IEnterState<TArgs> : IState
    {
        void Enter(TArgs args);
    }

    public interface IExitState : IState
    {
        void Exit();
    }

    public interface ITickState : IState
    {
        void Tick();
    }
}