using UnityEngine;

namespace Common
{
    public class RegisterSingletonReference : MonoBehaviour
    {
        [SerializeField]
        ObjectReference reference;

        private void OnEnable()
        {
            if (reference.Value == null)
                reference.Value = this.gameObject;
            else if(reference.Value != this.gameObject)
                Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            if (reference.Value == this.gameObject)
                reference.Value = null;
        }
    }
}
