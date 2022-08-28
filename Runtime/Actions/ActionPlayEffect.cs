using Common;
using UnityEngine;

namespace Actions
{
    public class ActionPlayEffect : MonoBehaviour
    {
        [SerializeField]
        Effect effect;

        public void Action_PlayEffect()
        {
            effect.TriggerEffect(this.gameObject.transform.position.V2());
        }
    }
}
