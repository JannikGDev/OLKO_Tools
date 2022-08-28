using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionDelay : MonoBehaviour
{
    [SerializeField]
    private UnityEvent Execute;

    [SerializeField]
    private float Delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        StartCoroutine(DelayedEvent());
    }

    private IEnumerator DelayedEvent()
    {
        yield return new WaitForSeconds(Delay);
        Execute?.Invoke();
    }
}
