using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {

    public List<AudioClip> sounds;
    public AudioSource Source;
    public AudioSource Source2;
    private bool usedFirst = false;

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
        if (usedFirst)
        {
            Source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
        }
        else
        {
            Source2.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
        }
        usedFirst = !usedFirst;
    }

}
