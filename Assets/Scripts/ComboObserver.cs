using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ComboObserver : MonoBehaviour {

    private static ComboObserver _instance;

    public static ComboObserver Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake() {
        _instance = this;
        idStack = new List<IdIfno>();
    }

    List<IdIfno> idStack;

    public bool SubmitID(Guid id)
    {
        bool found = false;
        foreach (var ids in idStack)
        {
            if (ids.guid == id)
            {
                found = true;
                ids.count++;
                if (ids.count > 8)
                {
                    return true;
                }
            }
        }
        if (!found)
        {
            if (idStack.Count > 1)
            {
                idStack.RemoveAt(0);
            }
            idStack.Add(new IdIfno()
            {
                guid = id,
                count = 1
            });
        }


        return false;
    }




}

[Serializable]
public class IdIfno
{
    public Guid guid;
    public int count;
}