using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SoundInfoContainer : ScriptableObject {



    private static SoundInfoContainer _instance;

    public List<Beat> Beats;

    public static SoundInfoContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<SoundInfoContainer>("SoundInfoContainer");
            }
            return _instance;
        }
    }

    
}

[Serializable]
public class Beat{
    public float Time;
    public Vector2 position;
    public bool HoldToUse;
}
