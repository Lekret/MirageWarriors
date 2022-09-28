using UnityEngine;

namespace GameMap
{
    public struct CellData
    {
        public Vector2 Position;
        public int Mirage;
    }
    
    public class Map : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _borders;

        private CellData[] _cellData;

        public void Init(int width, int height)
        {
            _cellData = new CellData[width * height];
        }

        public Vector2 GetRandomPoint()
        {
            var bounds = _borders.bounds;
            var min = bounds.min;
            var max = bounds.max;
            var randomX = Random.Range(min.x, max.x);
            var randomY = Random.Range(min.y, max.y);
            return new Vector2(randomX, randomY);
        }
    }
}