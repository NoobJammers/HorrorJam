using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    public AudioSource audioSourceBackGround, audioSourceBackGround2;
    public AudioSource audioSource;

    public AudioClip bulbCollected, bulbFixed, diaryRead, horrorViolin, bottleBreak, jumpScare, singleClap, tripleClap, bookShelfFall, thunder, keyCollected;


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


    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }

    public void PlayBG1(bool status)
    {
        if (status)
            audioSourceBackGround.Play();
        else
            audioSourceBackGround.Stop();
    }

    public void PlayBG2(bool status, AudioClip clip, float volume = 1f)
    {
        if (status)
        {
            audioSourceBackGround2.clip = clip;
            audioSourceBackGround2.Play();
            audioSourceBackGround2.volume = volume;
        }
        else
        {
            audioSourceBackGround2.Stop();
        }
    }



    // public void AudioSourceLooped(bool state)
    // {
    //     if (state)
    //         audioSource2.Play();
    //     else
    //         audioSource2.Stop();
    // }
}
