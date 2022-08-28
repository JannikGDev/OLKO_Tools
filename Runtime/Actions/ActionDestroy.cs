using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject Target;

    public void Action_Destroy()
    {
        if (Target == null)
            return;

        GameObject.Destroy(Target);
    }
}
