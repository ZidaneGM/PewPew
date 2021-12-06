using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefeDoisOlho : MonoBehaviour
{
    
    public Animator animState;
    
    public chefeDois chefe;

    void Start(){
        
        chefe = FindObjectOfType<chefeDois>();
    }
    void Update(){
        if (chefe.vida < 0){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D colisor){
        StartCoroutine(acertaOlho());
    }

    IEnumerator acertaOlho(){

      
        animState.SetInteger("transition", 1); // ativa animação de piscar
        GetComponent<Collider2D>().enabled = false;   //desativa o collider 
        chefe.vida -= 1; // tira 1 de vida do chefe

        yield return new WaitForSecondsRealtime(0.6f);
        animState.SetInteger("transition", 0); // volta animaçao normal
        GetComponent<Collider2D>().enabled = true;   //ativa o collider denovo 
        
    }
}
