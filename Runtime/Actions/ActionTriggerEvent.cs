using Systems.GameEventSystem;
using UnityEngine;

namespace Actions
{
    public class ActionTriggerEvent : MonoBehaviour
    {
        [SerializeField]
        GameEvent @event;

        public void Action_TriggerEvent()
        {
            if (@event != null)
                @event.Raise(this);
        }
    }
}
