using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation LoadOperation;
    private AsyncOperation UnloadOperation;

    [SerializeField]
    private float ExitWait;

    [SerializeField]
    private float EntryWait;

    [SerializeField]
    UnityEvent<float> OnLoadEntry;

    [SerializeField]
    UnityEvent<float> OnLoadExit;

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

        if(EntryWait > 0)
            yield return new WaitForSecondsRealtime(EntryWait);

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
        
        if (ExitWait > 0)
            yield return new WaitForSecondsRealtime(ExitWait);
        
        Destroy(this.gameObject);
    }

    protected virtual void LoadEntry() 
    {
        OnLoadEntry?.Invoke(EntryWait);
    }
    protected virtual void LoadExit() 
    {
        OnLoadExit?.Invoke(ExitWait);
    }
}
