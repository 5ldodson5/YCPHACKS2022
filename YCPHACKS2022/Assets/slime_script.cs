using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_script : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 movement;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.002f;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
 
    public float health;
    public float damage = 1;


    public Transform target;
    public float speed = 0.03f;
    public float distance;
    public bool canMove;
    public bool canHit = false;


    public void start(){
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = 4;
        canMove = true;
    }

    void Update(){
        
            distance = Vector2.Distance(transform.position, target.position);
            if(distance < 0.75f){
                if(distance<0.25f){
                  Attack();
                }else{
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
        
    
    }



    public void Attack(){
        animator.SetTrigger("Attack");
    }

    public void moveAgain(){
        canMove = true;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(canHit == true){
        if(other.tag == "Player"){
            PlayerController enemy = other.GetComponent<PlayerController>();
            if(enemy != null){
                enemy.Health(damage);
            }
            
        }
        }
        
}

public void hitYes(){
    canHit = true;
}

public void hitNo(){
    canHit = false;
}

/*

    public void FixedUpdate(){
         bool success = TryMove(movement);

        if(!success){
            success = TryMove(new Vector2(movement.x, 0));

            if(!success){
            success = TryMove(new Vector2(movement.y, 0));
        }
        }
    }



    private bool TryMove(Vector2 direction){
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                speed * Time.fixedDeltaTime + collisionOffset);

                if(count == 0){
                rb.MovePosition((Vector2)transform.position + direction * speed * Time.fixedDeltaTime);
                return true;
                }else
                {
                    return false;
                }
            }


*/


    public void Health(float damage){
        health -= damage;
        Hit();
        if(health <= 0){
            Defeated();
        }
        ///if(health<= 0){
          //  Defeated();
       // }
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void Hit(){
        animator.SetTrigger("Hit");
    }


    public void RemoveEnemy(){
        Destroy(gameObject);
    }
}
