using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configuration", fileName = "Configuration")]
    public class Configuration : ScriptableObject
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Prefabs _prefabs;

        public GameSettings GameSettings => _gameSettings;
        public Prefabs Prefabs => _prefabs;
    }
}