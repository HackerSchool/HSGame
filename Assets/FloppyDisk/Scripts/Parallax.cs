using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private GameObject cam;
    private Vector3 lastCamPos;
    public float parallaxEffect;
    public bool resetOn;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        lastCamPos = cam.transform.position;
        

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float dx = cam.transform.position.x - lastCamPos.x;
        transform.position += Vector3.right * dx * parallaxEffect;
        lastCamPos = cam.transform.position;

        if(cam.transform.position.x - transform.position.x >= length && resetOn) {
            transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
