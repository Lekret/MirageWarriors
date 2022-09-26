using Data;
using UnityEngine;

namespace Hero
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _actionArea;

        public void Init(HeroData data)
        {
            _actionArea.radius = data.ActionDiameter / 2f;
        }
    }
}
