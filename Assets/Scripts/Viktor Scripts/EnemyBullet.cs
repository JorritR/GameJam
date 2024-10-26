using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public float speed;

    public float lifetime;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, lifetime);
        //transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
        }
    }
}
