using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TransparencyTween : MonoBehaviour
{
    private float start;
    private float end;
    private float value;
    private float time;
    private float totalTime = -1;

    Image target;

    public void FadeIn(float time)
    {
        StartChange(0.0f, 1.0f, time);
    }

    public void FadeOut(float time)
    {
        StartChange(1.0f, 0.0f, time);
    }

    public void StartChange(float startVal, float endVal, float tweenTime)
    {
        totalTime = tweenTime;
        time = totalTime;
        start = startVal;
        end = endVal;
        value = start;
        target = GetComponent<Image>();

        var c = target.color;
        target.color = new Color(c.r, c.g, c.b, start);
    }

    void Update()
    {
        if (totalTime <= 0)
            return;

        var c = target.color;

        if (time <= 0)
        {
            totalTime = 0;
            target.color = new Color(c.r, c.g, c.b, end);
        }

        time -= Time.unscaledDeltaTime;
        value = start + (end - start) * (1 - time / totalTime);
        target.color = new Color(c.r, c.g, c.b, value);
    }
}
