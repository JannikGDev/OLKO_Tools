using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActivateObject : MonoBehaviour
{
    [SerializeField]
    GameObject Target;

    [SerializeField]
    bool activate = true;

    public void Action_ActivateObject()
    {
        Target.SetActive(activate);
    }

    public void Action_ActivateObject(bool activate)
    {
        Target.SetActive(activate);
    }
}
