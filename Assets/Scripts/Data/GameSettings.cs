using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "StaticData/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mirageCount;
        [SerializeField] private int _heroSwitchCount;

        public int MapWidth => _mapWidth;
        public int MapHeight => _mapHeight;
        public int MirageCount => _mirageCount;
        public int HeroSwitchCount => _heroSwitchCount;
    }
}