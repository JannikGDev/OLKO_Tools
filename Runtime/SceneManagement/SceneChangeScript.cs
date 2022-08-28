using System.Collections;
using System.Collections.Generic;
using SceneManagement;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScenePicker))]
public class SceneChangeScript : MonoBehaviour
{
    [SerializeField]
    private SceneLoader LoaderPrefab;

    public void ChangeScene()
    {
        var scenePath = this.GetComponent<ScenePicker>().scenePath;
        var Loader = Instantiate(LoaderPrefab, new Vector3(0,0,100),Quaternion.identity);
        Loader.StartLoading(scenePath);
    }
}
