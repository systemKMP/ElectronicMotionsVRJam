using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class EffectFactory : MonoBehaviour
{
    public List<Effect> Effects;

    private static EffectFactory _instance;

    public static EffectFactory Instance
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

    public void SpawnEffect(EffectType type, Vector3 location, float timer)
    {
        var eff = Effects.Find(n=>n.Type == type);
        var obj = Instantiate(eff.Object, location, Quaternion.identity) as GameObject;
        Destroy(obj, timer);
    }



}

[Serializable]
public class Effect
{
    public GameObject Object;
    public EffectType Type;
}

public enum EffectType { Simple = 0, Super = 1 }
