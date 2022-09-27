using UnityEngine;
using UnityEngine.EventSystems;

namespace Heroes
{
    public class HeroSprite : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.LogError("LOL");
        }
    }
}