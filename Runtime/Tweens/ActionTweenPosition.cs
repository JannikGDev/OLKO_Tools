using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.Events;

namespace Tweens
{
    public class ActionTweenPosition : MonoBehaviour
    {
        [SerializeField]
        PositionTweenData positionTween;

        [SerializeField]
        UnityEvent tweenFinished;

        public void ActionPlayTween(Vector2 direction)
        {
            if (positionTween == null || positionTween.time == 0)
                return;

            StartCoroutine(Tween(direction));
        }

        private IEnumerator Tween(Vector2 direction)
        {
            var easeFunc =
                EasingFunction.GetEasingFunctionDerivative(positionTween.easeFunction);

            var move = direction.normalized.V3() * positionTween.distance;

            float t = 0;
            while(t < positionTween.time)
            {
                t += Time.deltaTime;

                var easeVal = easeFunc.Invoke(0, positionTween.time, t);

                this.transform.position +=
                    move * (Time.deltaTime * easeVal);

                yield return new WaitForEndOfFrame();
            }

            tweenFinished.Invoke();

            yield return null;
        }
    }
}
