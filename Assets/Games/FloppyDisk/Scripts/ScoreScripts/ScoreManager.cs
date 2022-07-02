using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    public UnityEvent atZoneTwo;
    public UnityEvent atZoneThree;
    public UnityEvent atZoneFour; 

    void Start(){
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        atZoneTwo = new UnityEvent();
        atZoneTwo.AddListener(GameObject.Find("Player").GetComponent<AbilityManager>().ZoneTwo);

        atZoneThree = new UnityEvent();
        atZoneThree.AddListener(GameObject.Find("Player").GetComponent<AbilityManager>().ZoneThree);

        atZoneFour = new UnityEvent();
        atZoneFour.AddListener(GameObject.Find("Player").GetComponent<AbilityManager>().ZoneFour);

    }

    //Increases the score when a player collides with a ScoreZone collider
    private void OnTriggerExit2D(Collider2D other){
        score = score + 1;
        scoreText.text = "Score: " + score.ToString("");

        if (score==5){
            if (atZoneTwo != null){
                atZoneTwo.Invoke();
            }
        }
        if (score==10){
            if (atZoneThree != null){
                atZoneThree.Invoke();
            }
        }
        if (score==15){
            if (atZoneFour != null){
                atZoneFour.Invoke();
            }
        }
    }

    public string GetScore() {
        return score.ToString();
    }

    public void ResetStore() {
        score = 0;
    }

}
