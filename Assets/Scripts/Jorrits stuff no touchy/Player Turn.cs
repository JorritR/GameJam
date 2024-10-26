using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public Vector2 mousePosition;
    public Vector2 aimDirection;
        
    private float angelCooldown;

    public float angelstartCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(angelCooldown <= 0 && Input.GetButton("Jump")){
        angelCooldown = angelstartCooldown;
        //rotation
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Ensure the same z-plane for 2D

        // Calculate the direction vector from the player to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation (only z-axis for 2D)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
    }
       else {
        //rotation
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Ensure the same z-plane for 2D

        // Calculate the direction vector from the player to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation (only z-axis for 2D)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        angelCooldown -= Time.deltaTime;
        }
    }
}
