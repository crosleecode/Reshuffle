using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio instance;

    public AudioSource source;
    public AudioClip startClip;
    public AudioClip endClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    public void PlayStart()
    {
        if (startClip != null)
            source.PlayOneShot(startClip);
    }

    public void PlayEnd()
    {
        if (endClip != null)
            source.PlayOneShot(endClip);
    }
}
