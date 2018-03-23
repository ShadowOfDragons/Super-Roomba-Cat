using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSfx()
    {
        sfx.PlayOneShot(hover);
    }

    public void ClickSfx()
    {
        sfx.PlayOneShot(click);
    }

}
