using System;

namespace Services.MirageService
{
    public interface IMirageService
    {
        event Action<int> PlayerMirageChanged;
        event Action<int> EnemyMirageChanged;
        event Action PlayerWon;
        event Action EnemyWon;
        void AddToPlayer(int mirage);
        void AddToEnemy(int mirage);
    }
}