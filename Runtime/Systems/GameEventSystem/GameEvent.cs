using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> m_eventListeners = new List<IGameEventListener>();

    [SerializeField]
    [Tooltip("When set to true, everytime the event is fired will be written to the console")]
    private bool activateLogging;

    [SerializeField]
    [TextArea]
    [Tooltip("Describe the GameEvent here. This field has not functional use and is only to be used for documentation.")]
    private string description;


    public void Raise(Object sender)
    {
        if (activateLogging)
            Debug.Log($"{this.name} Event raised by {sender.name}"); 

        for (int i = m_eventListeners.Count -1; i >= 0; i--)
        {
            m_eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(IGameEventListener listener)
    {
        if (!m_eventListeners.Contains(listener))
            m_eventListeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener)
    {
        if (m_eventListeners.Contains(listener))
            m_eventListeners.Remove(listener);
    }
}
