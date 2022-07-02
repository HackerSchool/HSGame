using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString("");
    }
}
