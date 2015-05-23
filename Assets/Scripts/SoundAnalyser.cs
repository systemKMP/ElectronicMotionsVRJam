using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SoundAnalyser : MonoBehaviour
{

    List<float> data;
    int dataLength = 20;

    public float avgPeak;

    void Start()
    {
        data = new List<float>();
        AudioSource aud = GetComponent<AudioSource>();
        float[] samples = new float[aud.clip.samples * aud.clip.channels];
        aud.clip.GetData(samples, 0);
        int i = 0;
        SoundInfoContainer.Instance.Beats = new List<Beat>();

        while (i < samples.Length)
        {
            data.Add(samples[i]);
            //Debug.Log(samples[i]);
            if (data.Count > dataLength)
            {
                data.RemoveAt(0);
            }

            if (data.Count == dataLength &&  data.Average(n => n > 0.0f ? n : -n) > avgPeak)
            {
                SoundInfoContainer.Instance.Beats.Add(new Beat()
                {
                    Time = (float)(i - 1000.0f) / 88200.0f
                });
                i += 16000;
                //Debug.Log((float)i / 88200.0f);
                //Debug.Log(data.Average(n => n > 0.0f ? n : -n));

                data = new List<float>();
            }

            i+=2;
        }



        //aud.clip.SetData(samples, 0);
    }
}
