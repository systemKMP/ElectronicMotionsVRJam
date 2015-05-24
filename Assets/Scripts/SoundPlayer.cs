using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {

    public List<AudioClip> sounds;
    public AudioSource Source;
    public AudioSource Source2;
    private bool usedFirst = false;

    private int clipsPlayed;

    public AudioLowPassFilter LowPass;

    private static SoundPlayer _instance;

    public static SoundPlayer Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public void PlayRandomClip(float height = 0.0f)
    {
        clipsPlayed++;

        if (usedFirst)
        {
            Source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
            //Source.pitch = Mathf.Sin(clipsPlayed * Mathf.Deg2Rad * 180.0f) / 10.0f + 1.1f;
        }
        else
        {
            Source2.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
            //Source2.pitch = Mathf.Sin(clipsPlayed * Mathf.Deg2Rad * 180.0f) / 10.0f + 1.1f;
        }
        usedFirst = !usedFirst;

        LowPass.cutoffFrequency = Mathf.Sin(clipsPlayed * Mathf.Deg2Rad * 30.0f) * 10500.0f + 11500.0f;
    }

}
