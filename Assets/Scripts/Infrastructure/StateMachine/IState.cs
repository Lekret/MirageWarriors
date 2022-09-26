namespace Infrastructure.StateMachine
{
    public interface IState
    {
        
    }

    public interface IEnterState : IState
    {
        void Enter();
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