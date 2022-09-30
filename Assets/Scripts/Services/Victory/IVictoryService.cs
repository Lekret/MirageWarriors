using System;

namespace Services.Victory
{
    public interface IVictoryService
    {
        event Action PlayerWon;
        event Action EnemyWon;
        void TriggerPlayer();
        void TriggerEnemy();
    }
}