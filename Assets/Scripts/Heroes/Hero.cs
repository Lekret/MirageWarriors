using StaticData;
using UnityEngine;

namespace Heroes
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private ActionArea _actionArea;

        public void Init(HeroData data)
        {
            _actionArea.SetDiameter(data.ActionDiameter);
        }
    }
}
