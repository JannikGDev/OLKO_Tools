using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.Events;

namespace Tweens
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ActionTweenColor : MonoBehaviour
    {
        [SerializeField]
        ColorTweenData colorTween;

        [SerializeField]
        UnityEvent TweenFinished;

        private SpriteRenderer sprite;

        private void Start()
        {
            sprite = this.GetComponent<SpriteRenderer>();
        }

        public void ActionPlayTween()
        {
            if (colorTween == null || colorTween.time == 0)
                return;

            StartCoroutine(Tween());
        }

        public IEnumerator Tween()
        {
            var baseColor = sprite.color;
            var easeFunc =
                EasingFunction.GetEasingFunction(colorTween.easeFunction);

            float t = 0;
            while (t < colorTween.time)
            {
                t += Time.deltaTime;

                var easeVal = 1 - easeFunc.Invoke(0, colorTween.time, t);

                sprite.color = colorTween.blendType.Blend(baseColor, colorTween.colorChange, easeVal);

                yield return new WaitForEndOfFrame();
            }
            sprite.color = baseColor;
            TweenFinished.Invoke();

            yield return null;
        }
    }
}
