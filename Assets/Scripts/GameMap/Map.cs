using StaticData;
using UnityEngine;
using Utils;

namespace GameMap
{
    public struct CellData
    {
        public int Mirage;
    }
    
    public class Map : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _borders;

        private CellData[,] _cellData;

        public CellData this[int x, int y]
        {
            get => _cellData[x, y];
            set => _cellData[x, y] = value;
        }
        
        public void Init(GameSettings gameSettings)
        {
            var bounds = _borders.bounds;
            var min = bounds.min.ToVec2Int();
            var max = bounds.max.ToVec2Int();
            _cellData = new CellData[max.x, max.y];
            for (var x = min.x; x < max.x; x++)
            {
                for (var y = min.y; y < max.y; y++)
                {
                    _cellData[x, y] = new CellData(); 
                }
            }
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

        [ContextMenu("Position to origin")]
        private void PositionToOrigin()
        {
            var bounds = _borders.bounds;
            transform.position = bounds.max - bounds.center;
        }
    }
}