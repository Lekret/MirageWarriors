using System;
using StaticData;

namespace Services.MirageService
{
    public class MirageService : IMirageService
    {
        private readonly GameSettings _gameSettings;

        public MirageService(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public int PlayerMirage { get; private set; }
        public int EnemyMirage { get; private set; }
        public event Action<int> PlayerMirageChanged;
        public event Action<int> EnemyMirageChanged;
        public event Action EnemyWon;
        public event Action PlayerWon;

        public void AddToPlayer(int mirage)
        {
            PlayerMirage += mirage;
            PlayerMirageChanged?.Invoke(PlayerMirage);
            if (IsMirageAboveHalf(mirage))
                PlayerWon?.Invoke();
        }

        public void AddToEnemy(int mirage)
        {
            EnemyMirage += mirage;
            EnemyMirageChanged?.Invoke(EnemyMirage);
            if (IsMirageAboveHalf(mirage))
                EnemyWon?.Invoke();
        }

        private bool IsMirageAboveHalf(int mirage)
        {
            return mirage > _gameSettings.MirageCount / 2f;
        }
    }
}