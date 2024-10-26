using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D rb;
    public float movespeed = 2.5f;
    public float maxSpeed = 5f; // Define a maximum speed
    public Vector2 mousePosition;
    public Vector2 aimDirection;

    private void Start()
    {
        // Find the references to the "Move" action
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!Input.GetButton("Jump")) {
            // Read the "Move" action value
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // Apply force to the Rigidbody2D based on input and movespeed
        rb.AddForce(moveValue * movespeed);

        // Limit the velocity to the maxSpeed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        }
        

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
