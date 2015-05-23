using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SoundAnalyser : MonoBehaviour
{

    List<float> data;
    int dataLength;

    public float avgPeak;

    void Start()
    {
        data = new List<float>();
        AudioSource aud = GetComponent<AudioSource>();
        float[] samples = new float[aud.clip.samples * aud.clip.channels];
        aud.clip.GetData(samples, 0);
        int i = 0;



        while (i < samples.Length)
        {
            data.Add(samples[i]);
            if (data.Count > dataLength)
            {
                data.RemoveAt(0);
            }

            if (data.Average(n => n > 0 ? n : -n) > avgPeak)
            {
                data = new List<float>();
            }

            i++;
        }



        //aud.clip.SetData(samples, 0);
    }
}
