using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            //Camera.main.transform.position = camTarget.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            //Camera.main.transform.position = transform.position + new Vector3(0,0,-10);
        }
    }
}
