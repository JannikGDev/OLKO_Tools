using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlaySound : MonoBehaviour
{
    [SerializeField]
    SoundEffect soundEffect;

    public void Action_PlaySound()
    {
        if (soundEffect == null)
        {
            Debug.LogWarning($"Missing Soundeffect in {name}");
            return;
        }


        var source = this.GetComponent<AudioSource>();
        soundEffect.Play(source);
    }
}
