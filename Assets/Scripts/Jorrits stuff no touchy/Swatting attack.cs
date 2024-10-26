using UnityEngine;

public class Swattingattack : MonoBehaviour
{

    public Vector2 aimDirection;
        
    public Vector3 TargetDirection;

    private float angelCooldown;

    public float angelstartCooldown = 1;
    
    public Transform player;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angelCooldown = angelstartCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        if(player!=null){
            if(angelCooldown <= 0){
            angelCooldown = angelstartCooldown;
            TargetDirection = (player.transform.position - transform.position).normalized;

            // Calculate the direction vector from the player to the mouse

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg;

            // Apply the rotation (only z-axis for 2D)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-40));
            
        }
        
        else{
            TargetDirection = (player.transform.position - transform.position).normalized;

            // Calculate the direction vector from the player to the mouse

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg;

            // Apply the rotation (only z-axis for 2D)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-120));
            angelCooldown -= Time.deltaTime;
            angelCooldown -= Time.deltaTime;
        }
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player")
        { 
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
        }
    }
}
