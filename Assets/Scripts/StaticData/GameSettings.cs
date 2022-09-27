﻿using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mirageCount;
        [SerializeField] private int _heroSwitchCount;
        [SerializeField] private HeroData[] _playerTeam;
        [SerializeField] private HeroData[] _enemyTeam;

        public int MapWidth => _mapWidth;
        public int MapHeight => _mapHeight;
        public int MirageCount => _mirageCount;
        public int HeroSwitchCount => _heroSwitchCount;
        public HeroData[] PlayerTeam => _playerTeam;
        public HeroData[] EnemyTeam => _enemyTeam;
    }
}