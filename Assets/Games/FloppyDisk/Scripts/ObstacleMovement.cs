using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 5;
    public float obstacleSpeedFast = 150;

    bool dashing = false;
    float timer = 0;

    Rigidbody2D rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
    }

    //Dashed method, called by Dash method on ObstacleManager, changes speed of obstacle.
    public void Dashed(){

        rigidbodyComponent.velocity = Vector2.left * obstacleSpeedFast;

        dashing = true;
    }

    // Update is called once per frame
    // Counter to reset speed after dash ends
    void Update(){
        if (dashing){
            timer += Time.deltaTime;
            if (timer>=0.5f){
                rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
                timer = 0;
                dashing = false;
            }
        }
    }
}
