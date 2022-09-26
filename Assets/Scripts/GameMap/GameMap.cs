using UnityEngine;

namespace GameMap
{
    public struct CellData
    {
        public Vector2 Position;
        public int Mirage;
    }
    
    public class GameMap : MonoBehaviour
    {
        private CellData[] _cellData;

        public void Init(int width, int height)
        {
            _cellData = new CellData[width * height];
        }
    }
}