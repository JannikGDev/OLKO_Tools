using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject : ScriptableObject
{
    protected void OnEnable()
    {
        //Prevent object deletion when not used in active scene
        this.hideFlags = HideFlags.None;
        this.hideFlags |= (HideFlags.DontUnloadUnusedAsset);
    }
}
