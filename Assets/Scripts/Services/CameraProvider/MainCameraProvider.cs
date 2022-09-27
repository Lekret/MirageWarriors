using UnityEngine;

namespace Services.CameraProvider
{
    public class MainCameraProvider : ICameraProvider
    {
        private Camera _camera;

        public Camera GetCamera()
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
            return _camera;
        }
    }
}