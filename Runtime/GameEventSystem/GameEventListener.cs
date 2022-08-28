using System.Collections;
using System.Collections.Generic;
using Systems.GameEventSystem;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [Tooltip("Add a GameEvent objet here, that this script should respond to")]
    [SerializeField]
    private GameEvent @event;

    [Tooltip("Add any number of functions that should be called when the event was triggered")]
    [SerializeField]
    UnityEvent Action;

    private void OnEnable()
    {
        if (@event != null)
            @event.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (@event != null)
            @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Action?.Invoke();
    }
}
