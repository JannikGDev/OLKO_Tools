using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChangeSprite : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer Target;

    [SerializeField]
    Sprite sprite;

    public void Action_ChangeSprite()
    {
        if (Target == null)
            return;

        Target.sprite = sprite;
    }
}
