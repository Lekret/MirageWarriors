using System.Collections.Generic;
using UnityEngine;

namespace Services.FoundMirageService
{
    public class FoundMirageService : IFoundMirageService
    {
        private readonly HashSet<Vector2> _positions = new HashSet<Vector2>();

        public void AddPosition(Vector2 position)
        {
            _positions.Add(position);
        }

        public void RemovePosition(Vector2 position)
        {
            _positions.Remove(position);
        }

        public IReadOnlyCollection<Vector2> GetPositions()
        {
            return _positions;
        }
    }
}