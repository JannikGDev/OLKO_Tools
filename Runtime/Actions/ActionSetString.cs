using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetString : MonoBehaviour
{
    [SerializeField]
    StringValue reference;

    [SerializeField]
    string value;

    public void Action_SetString()
    {
        Action_SetString(value);
    }

    public void Action_SetString(string value)
    {
        reference.Value = value;
    }
}
