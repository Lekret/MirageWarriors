using System;
using Heroes;

namespace Services.MirageService
{
    public interface IMirageService
    {
        event Action<int> PlayerMirageChanged;
        event Action<int> EnemyMirageChanged;

        void AddMirage(Hero hero, int mirage);
    }
}