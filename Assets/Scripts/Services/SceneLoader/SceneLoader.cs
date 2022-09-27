using System;
using System.Collections;
using Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            _coroutineRunner.StartCoroutine(WaitForOperationEnd(operation, onLoaded));
        }

        private static IEnumerator WaitForOperationEnd(AsyncOperation operation, Action onLoaded)
        {
            yield return operation;
            onLoaded?.Invoke();
        }
    }
}