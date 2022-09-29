using System.Collections.Generic;
using UnityEngine;

namespace Services.FoundMirageService
{
    public interface IFoundMirageService
    {
        void AddPosition(Vector2 position);
        void RemovePosition(Vector2 position);
        IReadOnlyCollection<Vector2> GetPositions();
    }
}