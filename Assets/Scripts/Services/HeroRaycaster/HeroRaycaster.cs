using Heroes;
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

        public bool TryRaycast(out Hero hero)
        {
            var camera = _cameraProvider.GetCamera();
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.GetRayIntersection(ray);
            if (hit)
            {
                return hit.transform.TryGetComponent(out hero);
            }
            hero = null;
            return false;
        }
    }
}