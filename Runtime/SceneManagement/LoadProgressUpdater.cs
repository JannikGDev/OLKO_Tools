using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SceneManagement
{
    public class LoadProgressUpdater : MonoBehaviour
    {
        [SerializeField] private float updateInterval = 0.1f;

        [SerializeField] private UnityEvent<float> onLoadProgressFloat;
        
        [SerializeField] private UnityEvent<string> onLoadProgressText;
        
        public void ShowLoadProgress(AsyncOperation loadOperation)
        {
            StartCoroutine(UpdateProgress(loadOperation));
        }
    
        private IEnumerator UpdateProgress(AsyncOperation loadOperation)
        {
            while (!loadOperation.isDone)
            {
                onLoadProgressFloat.Invoke(loadOperation.progress);
                onLoadProgressText.Invoke(loadOperation.progress.ToString("P0"));
                yield return new WaitForSecondsRealtime(updateInterval);
            }
            onLoadProgressFloat.Invoke(1);
            onLoadProgressText.Invoke("100%");
        }
    }
}
