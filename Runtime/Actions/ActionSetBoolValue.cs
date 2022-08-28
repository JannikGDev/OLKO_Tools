using System.Collections;
using System.Collections.Generic;
using SOVariables;
using UnityEngine;

public class ActionSetBoolValue : MonoBehaviour
{
    [SerializeField]
    BoolValue reference;

    [SerializeField]
    bool value;

    public void Action_SetBool()
    {
        Action_SetBool(value);
    }

    public void Action_SetBool(bool value)
    {
        reference.Value = value;
    }
}
