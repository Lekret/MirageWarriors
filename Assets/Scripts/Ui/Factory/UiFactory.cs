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
            _uiRoot.GetComponent<Canvas>().worldCamera = Camera.main;
        }

        public SetupUi CreateSetupUi()
        {
            var setupUi = Object.Instantiate(_prefabs.SetupUi, _uiRoot);
            return setupUi;
        }
    }
}