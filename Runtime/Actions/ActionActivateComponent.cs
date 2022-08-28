using UnityEngine;

namespace Actions
{
    public class ActionActivateComponent : MonoBehaviour
    {
        [SerializeField]
        MonoBehaviour target;
        
        [Tooltip("Sets whether the target should be activated (true) or deactivated (false)")]
        [SerializeField]
        bool activate = true;

        public void Action_ActivateObject()
        {
            Action_ActivateObject(activate);
        }

        public void Action_ActivateObject(bool activate)
        {
            target.enabled = activate;
        }
    }
}
