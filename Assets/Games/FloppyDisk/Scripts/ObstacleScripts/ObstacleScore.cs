using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleScore : MonoBehaviour
{
    private UnityEvent obstaclePassed;

    void Start()
    {
        obstaclePassed = new UnityEvent();
        obstaclePassed.AddListener(GameObject.Find("ScoreController").GetComponent<ScoreController>().OnObstaclePassed);
    }

    private void OnTriggerExit2D(Collider2D other){
        obstaclePassed.Invoke();
    }
}
