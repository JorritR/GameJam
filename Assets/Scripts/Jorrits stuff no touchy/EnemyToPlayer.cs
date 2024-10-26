using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationspeed;
    [SerializeField]
    private bool allergic;
    private Rigidbody2D rigidbody;
    private Vector2 TargetDirection;
    public GameObject player;
    private int distanceToDespawn = 80;
    
    void Awake()
    {
    
        rigidbody =  GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update()
    {
        if(player!= null){
            if (Vector2.Distance(player.transform.position, transform.position) > distanceToDespawn)
            {
                Destroy(gameObject);
            }
            TargetDirection = (player.transform.position - transform.position).normalized;
        }
        

    }

    private void FixedUpdate()
    {
        if(player!= null){
            RotateTowardsTarget();
        }
        
        SetVelocity();

    }
    private void RotateTowardsTarget()
    {

        transform.up = TargetDirection;
    }
    private void SetVelocity()
    {
        if (player != null){
        if(allergic){
                rigidbody.linearVelocity = -transform.up * speed;
            }
        else{
                rigidbody.linearVelocity = transform.up * speed;
            }
        }
        else{
            rigidbody.linearVelocity= Vector2.zero;
        }
    }
}
