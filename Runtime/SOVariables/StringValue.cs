using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringValue", menuName = "DataObjects/String")]
public class StringValue : ValueObject
{
    public event Action OnValueChanged;

    [SerializeField]
    private string _value;
    public string Value
    {
        get => _value;
        set
        {
            if (_value == value)
                return;
            _value = value;
            OnValueChanged?.Invoke();
        }
    }
}
