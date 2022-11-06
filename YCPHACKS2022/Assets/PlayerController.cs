using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.002f;
    public Text UIText;
    //private Text UIText;

    [SerializeField] GameObject ArrowPrefab;



    Vector2 movementInput;
    Rigidbody2D rb;
    Transform trans;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator;

    SpriteRenderer spriteRenderer;
    float rot = 90;

    public float health;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        health = 4; 
    }

    public void Health(float damage){
        health -= damage;
       
      //  UIText.GetComponent<UnityEngine.UI.Text>().text =  health.ToString();
        //UIText.GetComponent<UnityEngine.UI.Text>().text = 
        if(health <= 0){
            RemoveEnemy();
        }
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
            rot = 90;
        }else if(movementInput.x > 0){
            animator.SetFloat("Left", -1);
            rot = 270;
        }else{
            animator.SetFloat("Left", 0);
        }

        if(movementInput.y > 0){
            animator.SetFloat("Down", -1);
            rot = 0;
            
        }else if(movementInput.y < 0){
            animator.SetFloat("Down", 1);
            rot = 180;
            
        }else{
            animator.SetFloat("Down", 0);
        }



        


    }

    public void RemoveEnemy(){
        Destroy(gameObject);
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



    void OnFire(){
        animator.SetTrigger("bowAttack");
    }

    void FireBow(){
        Quaternion ang = Quaternion.Euler(new Vector3(0f,0f,rot));
        Vector3 position = new Vector3(trans.position.x, trans.position.y-.05f, trans.position.z);
        Instantiate(ArrowPrefab, position, ang);
    }
}
