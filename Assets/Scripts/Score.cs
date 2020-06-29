using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private int ScoreValue;

    private void Start()
    {
        ScoreText.text = "Score: " + ScoreValue;
    }
    public void AddPoints(int points)
    {
        ScoreValue += points;
        ScoreText.text = "Score: " + ScoreValue; 
    }

    public void ReducePoints(int points)
    {
        ScoreValue -= points;
        ScoreText.text = "Score: " + ScoreValue;
    }
}
