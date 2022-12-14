using System.Collections.Generic;
using StaticData;
using UnityEngine;
using Utils;

namespace GameMap
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _borders;

        private Vector2Int _min;
        private Vector2Int _max;
        private CellData[,] _cellData;
        private readonly HashSet<Vector2Int> _miragePositions = new HashSet<Vector2Int>();

        public IReadOnlyCollection<Vector2Int> MiragePositions => _miragePositions;

        private void Awake()
        {
            var bounds = _borders.bounds;
            _min = bounds.min.ToVec2Int();
            _max = bounds.max.ToVec2Int();
            _cellData = new CellData[_max.x, _max.y];
            for (var x = _min.x; x < _max.x; x++)
            {
                for (var y = _min.y; y < _max.y; y++)
                {
                    _cellData[x, y] = new CellData(); 
                }
            }
        }

        public void Init(GameSettings gameSettings)
        {
            DistributeMirage(gameSettings.MirageCount);
        }

        public bool OpenCell(Vector2Int position)
        {
            ref var cell = ref _cellData[position.x, position.y];
            if (cell.IsOpen)
                return false;
            cell.IsOpen = true;
            if (cell.Mirage > 0)
            {
                _miragePositions.Add(position);
            }
            return true;
        }

        public int ExtractMirage(Vector2Int position)
        {
            ref var cell = ref _cellData[position.x, position.y];
            var mirage = 0;
            if (cell.IsOpen)
            {
                mirage = cell.Mirage;
                cell.Mirage = 0;
                _miragePositions.Remove(position);
            }
            return mirage;
        }
        
        public bool IsInBounds(int x, int y)
        {
            return x >= _min.x && x < _max.x &&
                   y >= _min.y && y < _max.y;
        }

        private void DistributeMirage(int mirageCount)
        {
            var width = _cellData.GetLength(0);
            var height = _cellData.GetLength(1);
            while (mirageCount > 0)
            {
                var rndWidth = Random.Range(0, width);
                var rndHeight = Random.Range(0, height);
                var rndMirage = Mathf.Min(10, mirageCount);
                _cellData[rndWidth, rndHeight].Mirage += rndMirage;
                mirageCount -= rndMirage;
            }
        }

        public Vector2 GetRandomPoint()
        {
            var randomX = Random.Range(_min.x, _max.x);
            var randomY = Random.Range(_min.y, _max.y);
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