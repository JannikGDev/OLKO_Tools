using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public abstract class VisualEffect : Effect
{
    [SerializeField]
    GameObject animationPrefab;

    public override void TriggerEffect(Vector2 position)
    {
        GameObject.Instantiate(animationPrefab, position.V3(), Quaternion.identity);
    }
}
