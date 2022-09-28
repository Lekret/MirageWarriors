using System;
using Heroes;

namespace Services.MirageService
{
    public interface IMirageService
    {
        event Action<int> PlayerMirageChanged;
        event Action<int> EnemyMirageChanged;
        event Action PlayerWon;
        event Action EnemyWon;
        void AddMirage(Hero hero, int mirage);
    }
}