using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    // Start is called before the first frame update
   public GameObject virtualCam;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(true);
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(false);
        }
    }

}