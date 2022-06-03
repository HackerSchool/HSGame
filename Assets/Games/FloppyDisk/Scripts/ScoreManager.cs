using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    void Start(){
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    //Increases the score when a player collides with a ScoreZone collider
    private void OnTriggerExit2D(Collider2D other){
        score = score + 1;
        scoreText.text = "Score: " + score.ToString("");
    }

    public string GetScore() {
        return score.ToString();
    }

    public void ResetStore() {
        score = 0;
    }

}
