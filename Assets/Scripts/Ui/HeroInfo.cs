using System;
using Heroes;
using Services.CameraProvider;
using Services.HeroStorage;
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
        private IHeroStorage _heroStorage;
        private Hero _currentHero;
        
        public void Init(ICameraProvider cameraProvider, IHeroStorage heroStorage)
        {
            _cameraProvider = cameraProvider;
            _heroStorage = heroStorage;
        }

        private void Awake()
        {
            Hide();
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.PointerEntered += SetHero;
                hero.PointerExited += TryHide;
            }
        }

        private void OnDestroy()
        {
            foreach (var hero in _heroStorage.GetAll())
            {
                hero.PointerEntered -= SetHero;
                hero.PointerExited -= TryHide;
            }
        }
        
        private void TryHide(Hero hero)
        {
            if (_currentHero == hero)
                Hide();
        }
        
        private void SetHero(Hero hero)
        {
            _currentHero = hero;
            gameObject.SetActive(true);
            var cam = _cameraProvider.GetCamera();
            var heroPosition = hero.transform.position;
            var screenPosition = cam.WorldToScreenPoint(heroPosition);
            transform.position = screenPosition;
            SetData(hero.Data);
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