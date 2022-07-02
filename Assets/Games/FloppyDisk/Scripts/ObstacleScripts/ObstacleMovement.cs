using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 5;
    public float obstacleSpeedFast = 10;

    bool dashing = false;

    bool rotating = false;
    //float timer = 0f;
    float position = 0f;

    float angle = 0.0f;

    Rigidbody2D rigidbodyComponent;


    void Start()
    {
    }

    //Dashed method, called by Dash method on ObstacleManager, changes speed of obstacle.
    public void Dashed(){
        transform.position += Vector3.left * obstacleSpeedFast * Time.deltaTime;
        dashing = true;
    }

    // Update is called once per frame
    // Counter to reset speed after dash ends
    void Update(){
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;
        if (dashing){
            if (rigidbodyComponent.transform.position.x <= (position-5f)){
                rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
                dashing = false;
            }
        }
    }

    public void Rotate() {
        rotating = true;
    }

    void OnBecameInvisible()
    {
        if(gameObject.transform.position.x < 0) {
            Destroy(gameObject);
        }
    }
}
