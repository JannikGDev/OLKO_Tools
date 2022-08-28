using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAnimationEnd : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnAnimEnd;

    public void AnimationEnd()
    {
        OnAnimEnd?.Invoke();
    }
}
