using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour {

    public Text ScoreText;
    public Text MultiplierText;

    public void UpdateScore(int score)
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }

    public void UpdateMultiplier(float multiplier)
    {
        MultiplierText.text = "MULTIPLIER: " + multiplier.ToString() + "x";
    }

    public void ResetMultiplier()
    {
        MultiplierText.text = "MULTIPLIER: 1.0x";
    }
}