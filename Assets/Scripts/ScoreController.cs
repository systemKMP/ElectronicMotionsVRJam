using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ScoreController : MonoBehaviour {

    private static ScoreController _instance;

    public static ScoreController Instance
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

    public ScoreUIManager UIManager;

    public bool CalculateTime;

    public int Score;
    public float Multiplier;
    public int ScorePerHitMin;

    public List<int> ScoresPerHit;
    public float MissTime;

    public float TimePassed = 0.0f;

    public void ReportScore(float targetTime)
    {
        int level = (int)Mathf.Abs((targetTime - TimePassed) / MissTime);
        if (level >= ScoresPerHit.Count){
            level = ScoresPerHit.Count-1;
        }


        Score += (int)(ScoresPerHit[level] * Multiplier);
        Multiplier += 0.2f;
        UIManager.UpdateMultiplier(Multiplier);
        UIManager.UpdateScore(Score);


    }

    public void ReportMin(float offset)
    {
        Score += (int)(ScorePerHitMin * Multiplier);
        UIManager.UpdateScore(Score);
    }

    public void ReportMiss()
    {
        Multiplier = 1.0f;
        UIManager.ResetMultiplier();
    }

    void Update()
    {
        if (CalculateTime)
        {
            TimePassed += Time.deltaTime;
        }
    }
}
