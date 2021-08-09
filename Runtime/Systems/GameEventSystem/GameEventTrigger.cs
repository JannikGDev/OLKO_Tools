using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Put the GameEvent Object to trigger here.")]
    private GameEvent @event;

    [SerializeField]
    [Tooltip("If set to true, this trigger will not fire more than once it its lifetime.")]
    private bool oneTimeTrigger;

    [SerializeField]
    [Tooltip("The trigger wont fire while this is false.")]
    public bool triggerEnabled = true;

    private void Start()
    {
        if(@event == null)
        {
            Debug.LogWarning("This GameEventTrigger has no GameEvent attached.");
        }
    }
    /// <summary>
    /// Triggers the attached event
    /// </summary>
    public void TriggerEvent()
    {
        if (@event != null)
            @event.Raise(this);
    }
}
