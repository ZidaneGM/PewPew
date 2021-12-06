using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaUP : MonoBehaviour
{   
    public GameController controller;

    // Start is called before the first frame update
    void Start(){
        controller = FindObjectOfType<GameController>();
    }
    void Update(){
        transform.position += Vector3.left * 6 * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D colisor){
        

        if (colisor.gameObject.CompareTag("player")){
            controller.lifeLose += 1;
            GetComponent<AudioSource>().Play();
            GetComponent<Collider2D>().enabled = false;   //desativa o collider 
            GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
            Destroy(gameObject, 2f); 
        }
        if (colisor.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
    }  
}
