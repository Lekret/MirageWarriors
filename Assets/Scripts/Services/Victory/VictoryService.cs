using System;
using Services.MirageService;

namespace Services.Victory
{
    public class VictoryService : IVictoryService
    {
        private IMirageService _mirageService;
        private bool _playerWon;
        private bool _enemyWon;

        public VictoryService(IMirageService mirageService)
        {
            _mirageService = mirageService;
        }

        public event Action PlayerWon;
        public event Action EnemyWon;
        
        public void TriggerPlayer()
        {
            if (IsTriggered())
                return;
            _playerWon = true;
            PlayerWon?.Invoke();
        }

        public void TriggerEnemy()
        {
            if (IsTriggered())
                return;
            _enemyWon = true;
            EnemyWon?.Invoke();
        }

        private bool IsTriggered()
        {
            return _playerWon || _enemyWon;
        }
    }
}