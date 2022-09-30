using System;
using Heroes;

namespace Services.MirageService
{
    public class MirageService : IMirageService
    {
        public int PlayerMirage { get; private set; }
        public int EnemyMirage { get; private set; }
        public event Action<int> PlayerMirageChanged;
        public event Action<int> EnemyMirageChanged;

        public void AddMirage(Hero hero, int mirage)
        {
            if (hero.State.IsPlayer)
                AddToPlayer(mirage);
            else
                AddToEnemy(mirage);
        }

        private void AddToPlayer(int mirage)
        {
            PlayerMirage += mirage;
            PlayerMirageChanged?.Invoke(PlayerMirage);
        }

        private void AddToEnemy(int mirage)
        {
            EnemyMirage += mirage;
            EnemyMirageChanged?.Invoke(EnemyMirage);
        }
    }
}