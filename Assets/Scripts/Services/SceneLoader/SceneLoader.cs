using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}