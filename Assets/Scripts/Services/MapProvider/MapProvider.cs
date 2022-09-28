using GameMap;
using UnityEngine;

namespace Services.MapProvider
{
    public class MapProvider : IMapProvider
    {
        private Map _map;

        public Map GetMap()
        {
            if (_map == null)
            {
                _map = Object.FindObjectOfType<Map>();
                if (_map == null)
                    Debug.LogError("[GetMap] Map not found");
            }
            return _map;
        }
    }
}