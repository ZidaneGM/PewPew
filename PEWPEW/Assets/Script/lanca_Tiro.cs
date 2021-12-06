using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanca_Tiro : MonoBehaviour
{
    public float speed;

   
    // Update is called once per frame
    void Update(){
        transform.position += Vector3.right * speed * Time.deltaTime;        
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("frente")){
            Destroy(gameObject);
        }
        if (colisor.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
    }

    
}

