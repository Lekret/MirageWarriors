using UnityEngine;

namespace Utils
{
    public static class VectorUtils
    {
        public static Vector2Int ToVec2Int(this Vector3 vec)
        {
            return new Vector2Int(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y));
        }
    }
}