using StaticData;
using UnityEngine;

namespace Ui.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly Prefabs _prefabs;
        private Transform _uiRoot;

        public UiFactory(Prefabs prefabs)
        {
            _prefabs = prefabs;
        }

        public void CreateUiRoot()
        {
            _uiRoot = Object.Instantiate(_prefabs.UiRoot).transform;
        }

        public SetupUi CreateSetupUi()
        {
            return Object.Instantiate(_prefabs.SetupUi, _uiRoot);
        }
    }
}