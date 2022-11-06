using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [HideInInspector] public float ArrowVelocity;
    [SerializeField] Rigidbody2D rb;
    public float damage = 1;

    



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            slime_script enemy = other.GetComponent<slime_script>();
            if(enemy != null){
                enemy.Health(damage);
                Destroy(gameObject);
            }else{
                boss_controller booga = other.GetComponent<boss_controller>();
                if(booga != null){
                booga.Health(damage);
                Destroy(gameObject);
            }
            }
            
        }
        else if(other.tag == "Collide"){
            Destroy(gameObject);
        }
    }
}

//
////            if(enemy != null){
//                enemy.Health -= damage;
 //               enemy.Hit();
//            }