﻿using Heroes;
using Services.CameraProvider;
using UnityEngine;

namespace Services.HeroRaycaster
{
    public class HeroRaycaster : IHeroRaycaster
    {
        private readonly ICameraProvider _cameraProvider;

        public HeroRaycaster(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }

        public bool TryGet(out Hero hero)
        {
            var camera = _cameraProvider.GetCamera();
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                Debug.LogError("Object; " + hit.transform.name, hit.transform);
                return hit.transform.TryGetComponent(out hero);
            }
            hero = null;
            return false;
        }
    }
}