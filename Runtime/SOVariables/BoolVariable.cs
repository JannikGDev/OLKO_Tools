using System;
using JetBrains.Annotations;
using UnityEngine;

namespace SOVariables
{
    [Serializable]
    public class BoolVariable
    {
        [SerializeField]
        public bool useReference;
        
        public bool Value
        {
            get
            {
                if (!useReference)
                    return value;

                if (reference is null)
                    throw new Exception($"Reference variable was not supplied!");
                
                value = reference.Value;
                return reference.Value;
            }
        }

        [SerializeField] [CanBeNull] 
        private BoolValue reference;

        [SerializeField]
        private bool value;
    }
}