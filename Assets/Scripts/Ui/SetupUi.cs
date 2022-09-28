using System.Collections.Generic;
using Heroes;
using Services.CameraProvider;
using Services.MapProvider;
using StateMachine;
using StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class SetupUi : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private HeroPreview[] playerPreviews;
        [SerializeField] private HeroPreview[] enemyPreviews;
        
        private IGameStateMachine _gameStateMachine;
        private ICameraProvider _cameraProvider;

        public void Init(
            IGameStateMachine gameStateMachine,
            IMapProvider mapProvider,
            ICameraProvider cameraProvider,
            GameSettings gameSettings)
        {
            _gameStateMachine = gameStateMachine;
            _cameraProvider = cameraProvider;
            UpdatePlayerPreviews(gameSettings.PlayerTeam);
            UpdateEnemyPreviews(mapProvider, gameSettings.EnemyTeam);
        }

        public IEnumerable<HeroPreview> GetPreviews()
        {
            var previews = new List<HeroPreview>();
            previews.AddRange(playerPreviews);
            previews.AddRange(enemyPreviews);
            return previews;
        }

        private void Awake()
        {
            _start.onClick.AddListener(StartPlaying);
        }

        private void OnDestroy()
        {
            _start.onClick.RemoveListener(StartPlaying);
        }
        
        private void UpdatePlayerPreviews(IReadOnlyList<HeroData> playerTeam)
        {
            var playerIdx = 0;
            foreach (var preview in playerPreviews)
            {
                preview.Data = playerTeam[playerIdx++];
                preview.IsPlayer = true;
            }
        }
        
        private void UpdateEnemyPreviews(
            IMapProvider mapProvider,
            IReadOnlyList<HeroData> enemyTeam)
        {
            var enemyIdx = 0;
            var cam = _cameraProvider.GetCamera();
            foreach (var preview in enemyPreviews)
            {
                var randomPoint = mapProvider.GetMap().GetRandomPoint();
                var screenPoint = cam.WorldToScreenPoint(randomPoint);
                preview.transform.position = screenPoint;
                preview.Data = enemyTeam[enemyIdx++];
                preview.IsPlayer = false;
            }
        }
        
        private void StartPlaying()
        {
            var spawnData = new List<HeroSpawnData>();
            PreviewToSpawnData(spawnData, playerPreviews);
            PreviewToSpawnData(spawnData, enemyPreviews);
            var args = new GameStateArgs(spawnData);
            _gameStateMachine.Enter<GameState, GameStateArgs>(args);
        }

        private void PreviewToSpawnData(
            ICollection<HeroSpawnData> spawnData,
            IEnumerable<HeroPreview> previews)
        {
            var cam = _cameraProvider.GetCamera();
            foreach (var preview in previews)
            {
                spawnData.Add(new HeroSpawnData(
                    preview.Data,
                    cam.ScreenToWorldPoint(preview.transform.position), 
                    preview.IsPlayer));
            }
        }
    }
}