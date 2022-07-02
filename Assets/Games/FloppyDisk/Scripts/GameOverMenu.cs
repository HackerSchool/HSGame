using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] IntVariable score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text += score.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
