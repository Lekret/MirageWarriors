using Services.CameraProvider;
using StaticData;
using UnityEngine;

namespace Ui.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly Prefabs _prefabs;
        private readonly ICameraProvider _cameraProvider;
        private Transform _uiRoot;

        public UiFactory(Prefabs prefabs, ICameraProvider cameraProvider)
        {
            _prefabs = prefabs;
            _cameraProvider = cameraProvider;
        }

        public void CreateUiRoot()
        {
            _uiRoot = Object.Instantiate(_prefabs.UiRoot).transform;
            var canvas = _uiRoot.GetComponent<Canvas>();
            canvas.worldCamera = _cameraProvider.GetCamera();
        }

        public HeroInfo CreateHeroInfo()
        {
            var heroInfo = Object.Instantiate(_prefabs.HeroInfo, _uiRoot);
            return heroInfo;
        }

        public SetupUi CreateSetup()
        {
            var setupUi = Object.Instantiate(_prefabs.SetupUi, _uiRoot);
            return setupUi;
        }
    }
}