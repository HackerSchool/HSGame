using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text += GameObject.Find("Score").GetComponent<ScoreManager>().GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
