using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 5;
    Rigidbody2D rigidbodyComponent;
    Collider2D colliderComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        colliderComponent = GetComponent<Collider2D>();
        rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Prevents collision with the ground
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Physics2D.IgnoreCollision(other.collider, colliderComponent);
            rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
        }
    }
}
