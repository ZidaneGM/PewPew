using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadenciaUp : MonoBehaviour
{
    
    //public float cadenciaInicial;       
    public GameObject boca;

    void Start(){

            boca= GameObject.FindGameObjectWithTag("boca"); 
    }
    void Update(){
        transform.position += Vector3.left * 6 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D colisor){
        

        if (colisor.gameObject.CompareTag("player")){
            //cadenciaInicial = boca[0].GetComponent<atirar>().maxTime; // pegar maxTime do scritp "Atirar" e coloca numa variavel nesse script
            GetComponent<AudioSource>().Play();
            StartCoroutine(powerUp());  // ativa efeito do power up       
        }
        if (colisor.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
    }   

    IEnumerator powerUp(){

        boca.GetComponent<atirar>().maxTime -= 0.2f; // colocar valor desse script direto no valor maxTime do script Atirar        
        GetComponent<Collider2D>().enabled = false;   //desativa o collider 
        GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite

        yield return new WaitForSecondsRealtime(4.0f); //espera 4 segundos 
        boca.GetComponent<atirar>().maxTime += 0.2f; // colocar valor desse script direto no valor maxTime do script Atirar
        Destroy(gameObject); //destroi o objeto do powerup
    } 
}
