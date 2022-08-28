using System.Collections;
using System.Collections.Generic;
using SOVariables;
using UnityEngine;
using UnityEngine.Events;

public class BoolValueChanged : MonoBehaviour
{
    [SerializeField]
    BoolValue Value;

    [SerializeField]
    UnityEvent OnTrue;

    [SerializeField]
    UnityEvent OnFalse;

    private void OnEnable()
    {
        Value.OnValueChanged += Observable_OnValueChanged;
    }

    private void Observable_OnValueChanged()
    {
        if (Value.Value)
            OnTrue.Invoke();
        else
            OnFalse.Invoke();
    }

    private void OnDisable()
    {
        Value.OnValueChanged -= Observable_OnValueChanged;
    }
}
