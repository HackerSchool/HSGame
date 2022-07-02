using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float speed = 1.5f;
    float angle = 0.0f;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Mathf.Cos(angle) * Time.deltaTime;
        angle = (angle + Time.deltaTime * speed) % (2 * Mathf.PI);
    }
}
