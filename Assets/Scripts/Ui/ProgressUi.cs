using Services.MirageService;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class ProgressUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerMirage;
        [SerializeField] private TextMeshProUGUI _enemyMirage;

        private IMirageService _mirageService;

        public void Init(IMirageService mirageService)
        {
            _mirageService = mirageService;
            mirageService.PlayerMirageChanged += SetPlayerMirage;
            mirageService.EnemyMirageChanged += SetEnemyMirage;
        }

        private void OnDestroy()
        {
            _mirageService.PlayerMirageChanged -= SetPlayerMirage;
            _mirageService.EnemyMirageChanged -= SetEnemyMirage;
        }

        private void SetPlayerMirage(int mirage)
        {
            _playerMirage.text = $"Player: {mirage}";
        }
        
        private void SetEnemyMirage(int mirage)
        {
            _enemyMirage.text = $"Enemy: {mirage}";
        }
    }
}