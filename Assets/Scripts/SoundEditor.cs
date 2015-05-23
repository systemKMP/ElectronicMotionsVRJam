using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SpecialIntervals{
    public float StartTime;
    public float EndTime;
}

public class SoundEditor : MonoBehaviour {


    public List<SpecialIntervals> Intervals;

	// Use this for initialization
	void Start () {
        bool left = true;
        foreach (var beat in SoundInfoContainer.Instance.Beats)
        {
            Vector2 pos;
            if (left)
            {
                beat.TargetType = ColliderType.LeftHand;
                pos.x = -0.5f;
            }
            else
            {
                beat.TargetType = ColliderType.RightHand;
                pos.x = 0.5f;
            }
            pos.y = UnityEngine.Random.Range(-0.5f, 0.5f);
            beat.position = pos;
            left = !left;
        }

        
        var beats = SoundInfoContainer.Instance.Beats;

        bool lNoteStart = true;
        bool rNoteStart = true;

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
                if (beats[i].TargetType == ColliderType.LeftHand)
                {
                    if (lNoteStart)
                    {
                        beats[i].CombineWithNext = true;
                    }
                    else
                    {
                        beats[i].CombineWithNext = false;
                    }
                    lNoteStart = !lNoteStart;
                }
                if (beats[i].TargetType == ColliderType.RightHand)
                {
                    if (rNoteStart)
                    {
                        beats[i].CombineWithNext = true;
                    }
                    else
                    {
                        beats[i].CombineWithNext = false;
                    }
                    rNoteStart = !rNoteStart;
                }
            }
            else
            {
                beats[i].CombineWithNext = false;
            }
        }
	}

}
