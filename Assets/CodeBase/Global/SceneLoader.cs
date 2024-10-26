using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeBase
{
    public class SceneLoader : MonoBehaviour
    {
        public void Load(string sceneName, UnityAction onLoaded = null)
        {
            StartCoroutine(LoadAsync(sceneName, onLoaded));
        }

        private IEnumerator LoadAsync(string sceneName, UnityAction onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                yield return null;
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone) yield return null;

            yield return new WaitForSeconds(2f); // 2 seconds for visual loading

            onLoaded?.Invoke();
        }
    }
}
