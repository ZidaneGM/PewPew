using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefeOlho : MonoBehaviour
{
    
    public Animator animState;
    public GameObject obst;
    public chefeUm chefe;

    void Start(){
        
        chefe = FindObjectOfType<chefeUm>();
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
        GameObject newObst = Instantiate(obst); // cria um inimigo quando tem o olho acertado
        newObst.transform.position = transform.position + new Vector3(-1.5f,-1.5f,0); // cria o inimigo na boca do chefe
        chefe.vida -= 1; // tira 1 de vida do chefe

        yield return new WaitForSecondsRealtime(3f);
        animState.SetInteger("transition", 0); // volta animaçao normal
        GetComponent<Collider2D>().enabled = true;   //ativa o collider denovo 
        
    }
}