using System;
using UnityEngine;

namespace SOVariables
{
    [Serializable]
    [CreateAssetMenu(fileName = "BoolValue", menuName = "DataObjects/BoolValue")]
    public class BoolValue : ValueObject, IObservableValue
    {
        public event Action OnValueChanged;

        [SerializeField]
        private bool _value;

        [SerializeField]
        private bool DefaultValue;

        protected new void OnEnable()
        {
            base.OnEnable();
            _value = DefaultValue;
        }

        public bool Value
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
}
