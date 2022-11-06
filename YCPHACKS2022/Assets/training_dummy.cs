using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training_dummy : MonoBehaviour
{
    Animator animator;

    public float Health{
        set{
            health = value;

            if(health<=0){
                Defeated();
            }
        }
        get{
            return health;
        }
    }

    public float health = 4;

    private void start(){
        animator = GetComponent<Animator>();
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }


    public void RemoveEnemy(){
        Destroy(gameObject);
    }
}
