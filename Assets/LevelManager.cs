using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int level = 0;
    public float score = 0;
    public UnityEvent levelUp;

    // Start is called befor; the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        if(score > 25*(level+1)) {
            level++;
            levelUp.Invoke();
        }
    }
}
