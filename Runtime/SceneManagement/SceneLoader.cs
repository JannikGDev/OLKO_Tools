using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        private AsyncOperation LoadOperation;
        private AsyncOperation UnloadOperation;
        
        [SerializeField]
        private float exitWait;

        [SerializeField]
        private float entryWait;

        [SerializeField] 
        private LoadProgressUpdater progressUpdater;
        
        [SerializeField]
        UnityEvent<float> onLoadEntry;

        [SerializeField]
        UnityEvent<float> onLoadExit;



        public void StartLoading(string scenePath)
        {
            if (string.IsNullOrEmpty(scenePath))
            {
                throw new System.Exception("Scene Path was not set!");
            }
            
            DontDestroyOnLoad(this);
         
            Time.timeScale = 0;

            StartCoroutine(LoaderUpdate(scenePath));
        }

        private IEnumerator LoaderUpdate(string scenePath)
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            LoadOperation = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
            LoadOperation.allowSceneActivation = false;

            LoadEntry();

            if(progressUpdater != null)
                progressUpdater.ShowLoadProgress(LoadOperation);
                
            if(entryWait > 0)
                yield return new WaitForSecondsRealtime(entryWait);

            while (LoadOperation.progress < 0.9f)
            {
                yield return null;
            }
        
            LoadOperation.allowSceneActivation = true;

            while (!LoadOperation.isDone)
            {
                yield return null;
            }

            var newScene = SceneManager.GetSceneByPath(scenePath);
            SceneManager.SetActiveScene(newScene);
        
            Time.timeScale = 1;

            LoadExit();
            
            if (exitWait > 0)
                yield return new WaitForSecondsRealtime(exitWait);
        
            Destroy(this.gameObject);
        }

       

        protected virtual void LoadEntry() 
        {
            onLoadEntry?.Invoke(entryWait);
        }
        protected virtual void LoadExit() 
        {
            onLoadExit?.Invoke(exitWait);
        }
    }
}
