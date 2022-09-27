using System.Collections;
using UnityEngine;

namespace Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}