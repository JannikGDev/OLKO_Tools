using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using static EasingFunction;

[CreateAssetMenu(fileName = "Position", menuName = "Tweens/Color")]
public class ColorTweenData : ScriptableObject
{
    [SerializeField]
    public BlendTypes.BlendType blendType;

    [SerializeField]
    public Color colorChange;

    [SerializeField]
    public float time;

    [SerializeField]
    public Ease easeFunction;
}
