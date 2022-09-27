using System;

namespace Services.SceneLoader
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}