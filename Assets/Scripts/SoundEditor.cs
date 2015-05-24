using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SpecialIntervals
{
    public float StartTime;
    public float EndTime;
}

public class SoundEditor : MonoBehaviour
{
    public List<SpecialIntervals> Intervals;
    public List<SpecialIntervals> Intervals2;

    // Use this for initialization
    void Start()
    {
        bool left = true;
        int index = 0;
        foreach (var beat in SoundInfoContainer.Instance.Beats)
        {
            float dist = (float)index / (float)SoundInfoContainer.Instance.Beats.Count;
            Vector2 pos;
            if (left)
            {
                beat.TargetType = ColliderType.LeftHand;
                pos.x = (UnityEngine.Random.value * -0.5f - 0.1f) * (dist / 2.0f + 0.5f);
            }
            else
            {
                beat.TargetType = ColliderType.RightHand;
                pos.x = (UnityEngine.Random.value * 0.5f + 0.1f) * (dist / 2.0f + 0.5f);
            }
            pos.y = UnityEngine.Random.Range(-0.5f, 0.7f) * (dist/2.0f + 0.5f);
            beat.position = pos;
            left = !left;
            index++;
        }


        var beats = SoundInfoContainer.Instance.Beats;

        //bool lNoteStart = true;
        //bool rNoteStart = true;

        int intervalIndex = 0;
        bool makingCombinations = false;
        for (int i = 0; i < beats.Count; i++)
        {
            if (Intervals.Count > intervalIndex && beats[i].Time > Intervals[intervalIndex].StartTime)
            {
                makingCombinations = true;
                if (beats[i].Time > Intervals[intervalIndex].EndTime)
                {
                    makingCombinations = false;
                    intervalIndex++;
                }
            }
            else
            {
                beats[i].CombineWithNext = false;
            }
            if (makingCombinations)
            {
                //if (beats[i].TargetType == ColliderType.LeftHand)
                //{
                    //if (lNoteStart)
                    //{
                    //    beats[i].CombineWithNext = true;
                    //}
                    //else
                    //{
                    //    beats[i].CombineWithNext = false;
                    //}
                //}
                //if (beats[i].TargetType == ColliderType.RightHand)
                //{
                    beats[i].CombineWithNext = UnityEngine.Random.value < ((float)i / beats.Count);
                    //if (rNoteStart)
                    //{
                    //    beats[i].CombineWithNext = true;
                    //}
                    //else
                    //{
                    //    if (UnityEngine.Random.value > 0.5f)
                    //    {
                    //        beats[i].CombineWithNext = false;
                    //    }
                    //    else
                    //    {
                    //        beats[i].CombineWithNext = true;
                    //    }
                    //}
                //}
            }
            else
            {
                beats[i].CombineWithNext = false;
            }
        }

        EditorUtility.SetDirty(SoundInfoContainer.Instance);
        EditorApplication.SaveAssets();
        

    }

}
