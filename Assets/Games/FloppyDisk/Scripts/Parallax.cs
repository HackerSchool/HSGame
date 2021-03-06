using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    public float speed;
    public float parallaxEffect;
    public bool resetOn;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {   
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += Vector3.right * speed * parallaxEffect * Time.deltaTime;

        if(-transform.position.x >= length && resetOn) {
            transform.position = originalPosition;
        }
    }
}