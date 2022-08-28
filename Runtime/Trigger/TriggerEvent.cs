using Systems.GameEventSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger
{
    public class TriggerEvent : MonoBehaviour, IGameEventListener
    {
        [SerializeField]
        GameEvent @event;

        [SerializeField]
        UnityEvent onTriggered;

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

        public void Trigger()
        {
            onTriggered.Invoke();
        }

        public void OnEventRaised()
        {
            Trigger();
        }
    }
}
