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
                if (_camera == null)
                    Debug.LogError("[GetCamera] Camera not found");
            }
            return _camera;
        }
    }
}