using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInterval : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnTriggered;

    [SerializeField]
    float intervalTime = 0.5f;

    [SerializeField]
    float randomTimeOffset = 0;

    [SerializeField]
    bool startOnAwake;

    private bool active;

    private void Start()
    {
        if (startOnAwake)
            StartInterval();
    }

    public void StartInterval()
    {
        active = true;
        StartCoroutine(TriggerPeriod());
    }

    public void StopInterval()
    {
        active = false;
        StopAllCoroutines();
    }

    private IEnumerator TriggerPeriod()
    {
        yield return new WaitForSeconds(intervalTime + Random.Range(-randomTimeOffset, randomTimeOffset));
        while (active)
        {
            OnTriggered.Invoke();
            yield return new WaitForSeconds(intervalTime + Random.Range(-randomTimeOffset, randomTimeOffset));
        }
    }
}
