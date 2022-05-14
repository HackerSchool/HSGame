using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int score;
    public GameObject darkness;
    public UnityEvent activateObstacleInvisibilty;
    public UnityEvent deactivateObstacleInvisibilty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Darkness() {
        GameObject.Instantiate(darkness);
    }

    void DisappearingObstacles() {
        activateObstacleInvisibilty.Invoke();
    }

    void normalObstacles() {
        deactivateObstacleInvisibilty.Invoke();
    }
}
