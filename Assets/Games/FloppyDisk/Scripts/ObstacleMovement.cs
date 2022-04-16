using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidbodyComponent;
    
    void Start()
    {
        float obstacleSpeed = 5;
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
