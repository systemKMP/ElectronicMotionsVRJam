using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {

    public List<AudioClip> sounds;
    public AudioSource Source;

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

    public void PlayRandomClip()
    {
        Source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
    }

}
