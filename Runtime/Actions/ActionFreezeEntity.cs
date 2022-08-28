using SOVariables;
using UnityEngine;

namespace Actions
{
    public class ActionFreezeEntity : MonoBehaviour
    {
        [Tooltip("Set a bool variable that shows whether the entity should be frozen or not")]
        [SerializeField]
        BoolValue shouldFreeze;

        public void OnEnable()
        {
            shouldFreeze.OnValueChanged += TriggerAction;
        }

        public void OnDisable()
        {
            shouldFreeze.OnValueChanged -= TriggerAction;
        }

        public void Start()
        {
            if(shouldFreeze.Value)
                Action_FreezeEntity();
        }

        public void TriggerAction()
        {
            if (shouldFreeze.Value)
                Action_FreezeEntity();
            else
                Action_UnFreezeEntity();
        }

        public void Action_FreezeEntity()
        {
            var components = this.gameObject.GetComponents<MonoBehaviour>();

            foreach(var comp in components)
            {
                if(comp != this)
                    comp.enabled = false;
            }
        }

        public void Action_UnFreezeEntity()
        {
            var components = this.gameObject.GetComponents<MonoBehaviour>();

            foreach (var comp in components)
            {
                if (comp != this)
                    comp.enabled = true;
            }
        }
    }
}
