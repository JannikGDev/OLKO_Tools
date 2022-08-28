using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerOnDestroy : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnTriggered;

    private void OnDestroy()
    {
        OnTriggered.Invoke();
    }
}
