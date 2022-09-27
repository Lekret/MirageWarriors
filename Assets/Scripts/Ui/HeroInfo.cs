using StaticData;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class HeroInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _initiative;
        [SerializeField] private TextMeshProUGUI _actionDiameter;
        [SerializeField] private TextMeshProUGUI _enthusiasm;
        [SerializeField] private TextMeshProUGUI _search;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _collection;
        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private TextMeshProUGUI _shield;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _cooldown;

        private void Awake()
        {
            Hide();
        }

        public void SetData(HeroData data)
        {
            gameObject.SetActive(true);
            _initiative.text = $"Initiative: {data.Initiative}";
            _actionDiameter.text = $"Action diameter: {data.ActionDiameter}";
            _enthusiasm.text = $"Enthusiasm: {data.Enthusiasm}";
            _search.text = $"Search: {data.Search}";
            _speed.text = $"Speed: {data.Speed}";
            _collection.text = $"Collection: {data.Collection}";
            _damage.text = $"Damage: {data.Damage}";
            _shield.text = $"Shield: {data.Shield}";
            _health.text = $"Health: {data.Health}";
            _cooldown.text = $"Cooldown: {data.Cooldown}";
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}