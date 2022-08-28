using UnityEngine;

namespace Common
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        ObjectReference target;

        private void Start()
        {
            CenterTarget();
        }

        // Update is called once per frame
        void Update()
        {
            CenterTarget();
        }

        private void CenterTarget()
        {
            if (target?.Value == null)
                return;

            var targetPos = target.Value.transform.position;

            this.transform.position = new Vector3(targetPos.x, targetPos.y, this.transform.position.z);
        }
    }
}
