namespace StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<T>() where T : IState;
        void Enter<T, TArgs>(TArgs args) where T : IEnterState<TArgs>;
    }
}