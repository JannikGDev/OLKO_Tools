using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectReference", menuName = "DataObjects/ObjectReference")]
class ObjectReference : ValueObject
{
    private new void OnEnable()
    {
        base.OnEnable();
        this._value = null;
    }

    public event Action OnReferenceChanged;

    private GameObject _value;

    public GameObject Value
    {
        get => _value;
        set
        {
            if (_value == value)
                return;
            _value = value;
            OnReferenceChanged?.Invoke();
        }
    }
}

