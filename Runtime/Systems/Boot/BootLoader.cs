using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroyOnLoad(this);
    }
}
