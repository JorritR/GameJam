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
    
    void Awake()
    {
    
        rigidbody =  GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update()
    {
        if(player!= null){
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
