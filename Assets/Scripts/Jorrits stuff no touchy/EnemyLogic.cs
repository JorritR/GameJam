using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float hp = 30;
    public float damagetaken = 30;
    private bool angel = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void dealDamage(float damagetaken){
        hp-= damagetaken;
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {   

        if(other.gameObject.tag == "Angel"&& Input.GetButton("Jump")){
            Debug.Log("hqahdufjdgf");
            dealDamage(damagetaken);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")){
            angel=true;
        }
        if(hp <= 0 )
        {   

            Destroy(gameObject);
;
        } 
    }
        
    
}