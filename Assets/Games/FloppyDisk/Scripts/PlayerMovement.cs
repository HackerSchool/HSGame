using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbodyComponent;
    public Animator animator;
    public GameObject darkness;
    public UnityEvent GameOver;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        animator.SetFloat("speedY", rigidbodyComponent.velocity.y);
    }

    void OnJump(InputValue value)
    {
        float jumpPower = 8f;
        rigidbodyComponent.velocity = Vector2.up * jumpPower;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Floor")
        {
            GameOver.Invoke();
        }
    }

}
