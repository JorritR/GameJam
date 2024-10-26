using UnityEngine;

public class Firing : MonoBehaviour
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        if (player != null)
        {
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
