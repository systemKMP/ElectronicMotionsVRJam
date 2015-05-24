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

    public ParticleSystem rHandP;
    public ParticleSystem lHandP;

    public float TimeSinceLastHit;

    public ScoreUIManager UIManager;

    public bool CalculateTime;

    public int Score;
    public int MultiplierCount;
    public int ScorePerHitMin;
    public int ScoresPerCombo;
    public List<int> ScoresPerHit;
    public float MissTime;

    public float TimePassed = 0.0f;

    public void ReportScore(float targetTime)
    {
        int level = (int)Mathf.Abs((targetTime - TimePassed) / MissTime);
        if (level >= ScoresPerHit.Count){
            level = ScoresPerHit.Count-1;
        }


        Score += (int)(ScoresPerHit[level] * (1.0f + MultiplierCount/5.0f));
        MultiplierCount++;
        UIManager.UpdateMultiplier(MultiplierCount);
        UIManager.UpdateScore(Score);
        UIManager.ShowMessage(level);

        TimeSinceLastHit = 0.0f;




    }

    public void ReportMin(float offset)
    {
        TimeSinceLastHit = 0.0f;
        Score += (int)(ScorePerHitMin * (1.0f + MultiplierCount/5.0f));
        UIManager.UpdateScore(Score);
    }

    public void ReportCombo()
    {
        TimeSinceLastHit = 0.0f;
        Score += (int)(ScoresPerCombo * (1.0f + MultiplierCount / 5.0f));
        UIManager.UpdateScore(Score);

    }

    public void ReportMiss()
    {
        MultiplierCount = 0;
        UIManager.ResetMultiplier();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }

        if (CalculateTime)
        {
            TimePassed += Time.deltaTime;
            TimeSinceLastHit += Time.deltaTime;        
        }

        if (TimeSinceLastHit > 5.0f)
        {
            float em = TimeSinceLastHit  * 40.0f;
            lHandP.emissionRate = rHandP.emissionRate = TimeSinceLastHit > 1000 ? 1000 : TimeSinceLastHit;

            Color c = lHandP.startColor;
            c.a = TimeSinceLastHit / 30.0f;
            rHandP.startColor = lHandP.startColor = c;
        } else {
            lHandP.emissionRate = rHandP.emissionRate = 0;

            Color c = lHandP.startColor;
            c.a = 0.0f;
            rHandP.startColor = lHandP.startColor = c;
        }
    }
}
