using UnityEngine;
using static EasingFunction;

namespace Tweens
{
    [CreateAssetMenu(fileName = "Position", menuName = "Tweens/Position")]
    public class PositionTweenData : ScriptableObject
    {
        [SerializeField]
        public float distance;

        [SerializeField]
        public float time;

        [SerializeField]
        public Ease easeFunction;
    }
}
