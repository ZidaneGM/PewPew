using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATField : MonoBehaviour
{
    //private float timer = 0f;
    //public float maxTime;
    public bool activeShield = false;

    // Update is called once per frame
    void Update()  {

        if (activeShield == false){
            StartCoroutine(ativar());
        }
        
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("lanca")){
            Destroy(colisor.gameObject);
        }
    }


    IEnumerator ativar(){

        activeShield = true;
        GetComponent<Collider2D>().enabled = true;   //ativa o collider 
        GetComponent<SpriteRenderer>().enabled = true; // ativa o sprite
        yield return new WaitForSecondsRealtime(2.0f);
        
        GetComponent<Collider2D>().enabled = false;   //desativa o collider 
        GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
        yield return new WaitForSecondsRealtime(2.0f);
        activeShield = false;

    }
}
