using System.Collections.Generic;
using Heroes;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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
        [SerializeField] private TextMeshProUGUI _character;

        private IEnumerable<HeroPreview> _previews;
        private HeroPreview _currentPreview;
        
        public void Init(IEnumerable<HeroPreview> previews)
        {
            _previews = previews;
            foreach (var data in previews)
            {
                data.InteractStarted += ShowPreview;
                data.InteractEnded += TryHide;
            }
            Hide();
        }

        private void OnDestroy()
        {
            foreach (var preview in _previews)
            {
                preview.InteractStarted -= ShowPreview;
                preview.InteractEnded -= TryHide;
            }
        }
        
        private void TryHide(HeroPreview preview)
        {
            if (_currentPreview == preview)
                Hide();
        }
        
        private void ShowPreview(HeroPreview preview, PointerEventData eventData)
        {
            if (_currentPreview != null && _currentPreview.IsDragged)
                return;
            _currentPreview = preview;
            gameObject.SetActive(true);
            transform.position = preview.transform.position;
            SetData(preview.Data);
        }
        
        private void SetData(HeroData data)
        {
            _initiative.text = $"Initiative: {data.Initiative}";
            _actionDiameter.text = $"Diameter: {data.ActionDiameter}";
            _enthusiasm.text = $"Enthusiasm: {data.Enthusiasm}";
            _search.text = $"Search: {data.Search}";
            _speed.text = $"Speed: {data.Speed}";
            _collection.text = $"Collection: {data.Collection}";
            _damage.text = $"Damage: {data.Damage}";
            _shield.text = $"Shield: {data.Shield}";
            _health.text = $"Health: {data.Health}";
            _cooldown.text = $"Cooldown: {data.Cooldown}";
            _character.text = $"Character: {data.Character}";
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}