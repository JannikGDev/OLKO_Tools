using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerOnStart : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnTriggered;

    private bool triggered = false;

    private void Update()
    {
        if (triggered)
            return;

        OnTriggered?.Invoke();
        Destroy(this);
    }
}
