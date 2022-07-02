using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level1 : MonoBehaviour
{
    bool started = false;
    public GameObject obstacleManager;
    public UnityEvent deactivateObstacles;
    public UnityEvent activateObstacles;
    [SerializeField] UnityEvent activateBoss;
    [SerializeField] IntVariable score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started) {
            if(score.value > 4 && score.value < 40) {
                activateBoss.Invoke();
                started = false;
            }
        }
    }

    public void StartLevel() {
        started = true;
        obstacleManager.SetActive(true);
    }

    public void StopLevel() {
        started = false;
    }
}
