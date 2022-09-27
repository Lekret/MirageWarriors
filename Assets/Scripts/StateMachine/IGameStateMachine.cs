namespace StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<T>() where T : IState;
    }
}