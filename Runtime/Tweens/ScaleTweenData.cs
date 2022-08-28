using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EasingFunction;

[CreateAssetMenu(fileName ="ScaleTweenData", menuName ="Tweens/Scale")]
public class ScaleTweenData : ScriptableObject
{
    [SerializeField]
    public Vector3 targetScale;

    [SerializeField]
    public float time;

    [SerializeField]
    public Ease easeFunction;
}
