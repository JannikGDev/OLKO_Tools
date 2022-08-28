using System.Collections.Generic;
using UnityEngine;

namespace Systems.GameEventSystem
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> mEventListeners = new List<IGameEventListener>();

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

            for (int i = mEventListeners.Count -1; i >= 0; i--)
            {
                mEventListeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!mEventListeners.Contains(listener))
                mEventListeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (mEventListeners.Contains(listener))
                mEventListeners.Remove(listener);
        }
    
        protected void OnEnable()
        {
            //Prevent object deletion when not used in active scene
            this.hideFlags = HideFlags.None;
            this.hideFlags |= (HideFlags.DontUnloadUnusedAsset);
        }
    }
}
