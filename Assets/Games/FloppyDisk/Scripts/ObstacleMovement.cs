using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed = 5;
    public float obstacleSpeedFast = 10;

    bool dashing = false;
    //float timer = 0f;
    float position = 0f;

    Rigidbody2D rigidbodyComponent;


    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
    }

    //Dashed method, called by Dash method on ObstacleManager, changes speed of obstacle.
    public void Dashed(){

        rigidbodyComponent.velocity = Vector2.left * obstacleSpeedFast;
        position = rigidbodyComponent.transform.position.x;

        dashing = true;
    }

    // Update is called once per frame
    // Counter to reset speed after dash ends
    void Update(){
        if (dashing){
            if (rigidbodyComponent.transform.position.x <= (position-5f)){
                rigidbodyComponent.velocity = Vector2.left * obstacleSpeed;
                dashing = false;
            }
        }
    }

    void OnBecameInvisible()
    {
        if(gameObject.transform.position.x < 0) {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
