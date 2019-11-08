using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BackgroundMusic;
    public AudioSource SoundEffect;

    public AudioClip RoadCreateClip;

    public void RoadCreateSound()
    {
        SoundEffect.PlayOneShot(RoadCreateClip);
    }
}