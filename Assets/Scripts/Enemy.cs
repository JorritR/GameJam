using UnityEngine;

public class Enemy: MonoBehaviour
{
    public Transform player;

    private float shotCooldown;

    public float startShotCooldown;

    public GameObject bulletPrefab;

    public Transform firingPoint;

    private void Start()
    {
        shotCooldown = startShotCooldown;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            transform.up = direction;

            if (shotCooldown <= 0)
            {
                Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
                shotCooldown = startShotCooldown;
            }
            else
            {
                shotCooldown -= Time.deltaTime;
            }
        }


    }
}
