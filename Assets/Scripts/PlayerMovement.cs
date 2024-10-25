using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D rb;
    public float movespeed = 1;
    private void Start()
    {
        // 3. Find the references to the "Move" and "Jump" actions
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 4. Read the "Move" action value, which is a 2D vector
        // and the "Jump" action state, which is a boolean value

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        rb.AddForce(moveValue * movespeed);


        /*

        float x = moveValue.x;
        float y = moveValue.y;
        transform.position += new Vector3(x*movespeed, y*movespeed, 0);
        */
        // your movement code here
    }
}
