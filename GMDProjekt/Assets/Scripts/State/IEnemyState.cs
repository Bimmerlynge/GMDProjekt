namespace State
{
    public interface IEnemyState
    {
        void Process();
        void Enter();
        void Update();
        void Exit();

    }
}