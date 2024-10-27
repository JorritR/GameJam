using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D rb;
    public static PlayerMovement instance;
    public float movespeed = 2.5f;
    public float maxSpeed = 5f; // Define a maximum speed
    public Vector2 mousePosition;
    public Vector2 aimDirection;
    public bool playerAlive = true;
    public SpriteRenderer spriteRenderer;
    public Sprite evolution1;
    public Sprite evolution2;

    public RuntimeAnimatorController evolution1_animation;
    public RuntimeAnimatorController evolution2_animation;

    public Animator animator;

    public Image deathImage;

    public Sprite evo2Image;
    public Sprite evo3Image;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Find the references to the "Move" action
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerAlive){
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
                //HealthBar.takeDamage(10);
        }
        }
        else{
            rb.linearVelocity=Vector2.zero;
        }      
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
        // Find the object with the "Player" tag in the hierarchy
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
            {
                LevelManager.manager.GameOver();
                Destroy(player);  // Destroys the "Player" object only
                playerAlive=false;
            }
        }
    }

    public void evolve(int evolutionLevel)
    {
        if (evolutionLevel == 1)
        {   
            movespeed = 2.75f;
            spriteRenderer.sprite = evolution1;
            maxSpeed = 7f;
            animator.runtimeAnimatorController = evolution1_animation;
            deathImage.sprite = evo2Image;
        }
        else if (evolutionLevel == 2)
        {
            movespeed = 3f;
            spriteRenderer.sprite = evolution2;
            maxSpeed = 10f;
            animator.runtimeAnimatorController = evolution2_animation;
            deathImage.sprite = evo3Image;
        }
        else
        {
            return;
        }
    }
}
