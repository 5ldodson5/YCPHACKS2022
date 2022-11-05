using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.002f;



    Vector2 movementInput;
    Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

  
    private void FixedUpdate(){
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);

        if(!success){
            success = TryMove(new Vector2(movementInput.x, 0));

            if(!success){
            success = TryMove(new Vector2(movementInput.y, 0));
        }
        }
        animator.SetBool("isMoving", success);
        }else{
            animator.SetBool("isMoving", false);
        }
        if(movementInput.x <0){
            animator.SetFloat("Left", 1);
        }else if(movementInput.x > 0){
            animator.SetFloat("Left", -1);
        }else{
            animator.SetFloat("Left", 0);
        }

        if(movementInput.y > 0){
            animator.SetFloat("Down", -1);
            
        }else if(movementInput.y < 0){
            animator.SetFloat("Down", 1);
            
        }else{
            animator.SetFloat("Down", 0);
        }



        


    }
    



    private bool TryMove(Vector2 direction){
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

                if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
                }else
                {
                    return false;
                }
            }



    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
}
