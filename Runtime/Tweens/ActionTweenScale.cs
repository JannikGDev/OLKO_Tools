using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTweenScale : MonoBehaviour
{
    [SerializeField]
    ScaleTweenData scaleTween;

    [SerializeField]
    UnityEvent TweenFinished; 

    public void ActionPlayTween()
    {
        if (scaleTween == null || scaleTween.time == 0)
            return;

        StartCoroutine(Tween());
    }

    public IEnumerator Tween()
    {
        var easeFunc =
               EasingFunction.GetEasingFunction(scaleTween.easeFunction);

        var startScale = this.transform.localScale;

        float t = 0;
        while (t < scaleTween.time)
        {
            t += Time.deltaTime;

            var easeVal = easeFunc.Invoke(0, 1, t/scaleTween.time);

            this.transform.localScale = easeVal*(scaleTween.targetScale - startScale)+startScale;

            yield return new WaitForEndOfFrame();
        }
        TweenFinished.Invoke();
    }
}
