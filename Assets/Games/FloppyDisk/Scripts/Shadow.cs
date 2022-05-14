using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public GameObject player;
    private Vector3 lastPlayerPos;
    private float maxScale = 1.2f;
    private float minScale = 0.8f;
    private float xyRatio;
    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPos = player.transform.position;
        xyRatio = transform.localScale.y/transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float dy = -(player.transform.position.y - lastPlayerPos.y);
        transform.localScale += new Vector3(dy*0.7f, dy*0.5f, 0);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, minScale, maxScale),
                                           Mathf.Clamp(transform.localScale.y, minScale*xyRatio, maxScale*xyRatio),
                                           1);
        lastPlayerPos =  player.transform.position;
    }
}
