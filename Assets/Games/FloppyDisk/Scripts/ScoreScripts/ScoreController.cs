using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [SerializeField] GameController controller;

    public void OnObstaclePassed()
    {
        controller.IncreaseScore(1);
    }
}
