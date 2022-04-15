using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Vector3 offset;
    private Rigidbody2D rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    void OnJump(InputValue value)
    {
        float jumpPower = 8f;
        Debug.Log("saltei");
        rigidbodyComponent.velocity = Vector2.up * jumpPower;
        //rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
        }
    }

}
