using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Vector3 offset;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        offset = value.Get<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        transform.position += speed*Time.deltaTime*offset;
    }

}
