using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoInimigo : MonoBehaviour
{
    public float speed;
    public GameController controller;
   
   void Start(){
        controller = FindObjectOfType<GameController>();
    }
    // Update is called once per frame
    void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;        
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
        if (colisor.gameObject.CompareTag("player")){
            controller.lifeLose -=1;
            Destroy(gameObject);
        }
        if (colisor.gameObject.CompareTag("skillExplosao")){
            Destroy(gameObject);
        }
    }

    
}
