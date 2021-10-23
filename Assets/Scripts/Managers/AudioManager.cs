using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    public AudioSource audioSourceBackGround;
    public AudioSource audioSource;

    public AudioClip win, lose;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    public void PlaySFX(AudioClip clip, float volume = 0.2f)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }

    // public void AudioSourceLooped(bool state)
    // {
    //     if (state)
    //         audioSource2.Play();
    //     else
    //         audioSource2.Stop();
    // }
}
