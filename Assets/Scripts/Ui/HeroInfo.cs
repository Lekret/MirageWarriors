using System.Collections.Generic;
using Heroes;
using Services.CameraProvider;
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

        private ICameraProvider _cameraProvider;
        private IEnumerable<HeroPreview> _previews;
        private HeroPreview _currentPreview;
        
        public void Init(ICameraProvider cameraProvider, IEnumerable<HeroPreview> previews)
        {
            _previews = previews;
            _cameraProvider = cameraProvider;
            foreach (var data in previews)
            {
                data.PointerEntered += SetHero;
                data.PointerExited += TryHide;
            }
            Hide();
        }

        private void OnDestroy()
        {
            foreach (var preview in _previews)
            {
                preview.PointerEntered -= SetHero;
                preview.PointerExited -= TryHide;
            }
        }
        
        private void TryHide(HeroPreview preview)
        {
            if (_currentPreview == preview)
                Hide();
        }
        
        private void SetHero(HeroPreview preview)
        {
            _currentPreview = preview;
            gameObject.SetActive(true);
            var cam = _cameraProvider.GetCamera();
            var heroPosition = preview.transform.position;
            var screenPosition = cam.WorldToScreenPoint(heroPosition);
            transform.position = screenPosition;
            SetData(preview.Data);
        }
        
        private void SetData(HeroData data)
        {
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

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}