using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Collider2D hand;

       public float damage = 1;
        public bool canHit = false;
    

    void Start()
    {
        hand.GetComponent<Collider2D>();
    }


    void delete()
    {
        Destroy(gameObject);
    }


private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerController enemy = other.GetComponent<PlayerController>();
            if(enemy != null){
                enemy.Health(damage);
            }
        }
    }

    public void hitYes(){
    hand.enabled = true;
}

public void hitNo(){
    hand.enabled = false;
}


}
