using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class AbilityManager : MonoBehaviour
{
    float bouncePower = 8f;

    public UnityEvent atDash;
    public UnityEvent atPull;

    Rigidbody2D rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        if (atDash == null){
            atDash = new UnityEvent();
        }
        if (atPull == null){
            atPull = new UnityEvent();
        }
    }

    //onDash input, begins atDash event
    void OnDash(InputValue value)
    {   
        rigidbodyComponent.velocity = Vector2.down*0;

        if (atDash != null){
            atDash?.Invoke();
        }
    }

    //onPull input, begins atPull event
    void OnPull(InputValue value){
        if (atPull != null){
            atPull?.Invoke();
        }
        
    }

    //onGhost input, no event required
    void OnGhost(InputValue value){
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 2.0f, 0.5f);
    }


    //methods to handle ghostly collisions
    //when leaving an obstacle remove invincibility
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Obstacle")){
            GetComponent<Collider2D>().isTrigger = false;
            GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    //when colliding with the floor, makes the player bounce without loosing invincibility
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Floor")){
            if (GetComponent<Collider2D>().isTrigger == true){
                rigidbodyComponent.velocity = Vector2.up * bouncePower;
            }
        }
    }
}
