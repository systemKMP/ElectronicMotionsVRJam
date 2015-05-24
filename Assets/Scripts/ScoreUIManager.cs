using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour {

    public Text ScoreText;
    public Text MultiplierText;

    public float ScoreScale;
    public float MultiplierScale;

    public GameObject[] PerformanceTexts;

    public void UpdateScore(int score)
    {
        ScoreScale = 1.2f;
        ScoreText.text = "SCORE: " + score.ToString();
    }


    public void ShowMessage(int level)
    {
        Instantiate(PerformanceTexts[level], PerformanceTexts[level].transform.position, Quaternion.identity);
    }

    public void UpdateMultiplier(float multiplier)
    {
        MultiplierScale = 1.2f;
        MultiplierText.text = "MULTIPLIER: " + (1.0f + multiplier/5.0f).ToString() + "x";
    }

    public void ResetMultiplier()
    {
        ShowMessage(5);
        MultiplierScale = 1.0f;
        MultiplierText.text = "MULTIPLIER: 1.0x";
    }

    void Update()
    {
        MultiplierText.transform.localScale = MultiplierScale * Vector3.one;
        ScoreText.transform.localScale = ScoreScale * Vector3.one;

        MultiplierScale = Mathf.MoveTowards(MultiplierScale, 1.0f, Time.deltaTime);
        ScoreScale = Mathf.MoveTowards(ScoreScale, 1.0f, Time.deltaTime);

    }

    
}