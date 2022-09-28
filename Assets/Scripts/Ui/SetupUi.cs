using System.Collections.Generic;
using Heroes;
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
        public IEnumerable<HeroPreview> PlayerPreviews => playerPreviews;

        public void Init(
            IGameStateMachine gameStateMachine,
            IMapProvider mapProvider,
            GameSettings gameSettings)
        {
            _gameStateMachine = gameStateMachine;
            var playerIdx = 0;
            foreach (var preview in playerPreviews)
            {
                preview.Data = gameSettings.PlayerTeam[playerIdx++];
            }

            var enemyIdx = 0;
            foreach (var preview in enemyPreviews)
            {
                var randomPoint = mapProvider.GetMap().GetRandomPoint();
                preview.transform.position = randomPoint;
                preview.Data = gameSettings.EnemyTeam[enemyIdx++];
            }
        }

        private void Awake()
        {
            _start.onClick.AddListener(StartPlaying);
        }

        private void OnDestroy()
        {
            _start.onClick.RemoveListener(StartPlaying);
        }
        
        private void StartPlaying()
        {
            var spawnData = new List<HeroSpawnData>();
            ConvertToSpawnData(spawnData, playerPreviews, true);
            ConvertToSpawnData(spawnData, enemyPreviews, false);
            var args = new GameStateArgs(spawnData);
            _gameStateMachine.Enter<GameState, GameStateArgs>(args);
        }

        private static void ConvertToSpawnData(
            ICollection<HeroSpawnData> spawnData,
            IEnumerable<HeroPreview> previews,
            bool isPlayer)
        {
            foreach (var preview in previews)
            {
                spawnData.Add(new HeroSpawnData(
                    preview.Data, 
                    preview.transform.position, 
                    isPlayer));
            }
        }
    }
}