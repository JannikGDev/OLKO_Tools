using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector2Value", menuName = "DataObjects/Vector2Value")]
public class Vector2Value : ValueObject, IObservableValue
{
    public event Action OnValueChanged;

    private Vector2 _value;

    public Vector2 Value
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
