using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoMestre : MonoBehaviour
{
    public float speed;
    public GameController controller;
    //private Transform player;
    public GameObject explosao;
   
   void Start(){
        controller = FindObjectOfType<GameController>();
        //player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, player.position, (speed) * Time.deltaTime);        
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
        if (colisor.gameObject.CompareTag("player")){
            controller.lifeLose -=1;
            Destroy(gameObject);
        }
        if (colisor.gameObject.CompareTag("lanca")){
            GetComponent<Collider2D>().enabled = false;   //desativa o collider
            speed = 0; // pro tiro ficar parado
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f); //destruir esplosaõ depois de 0.5s (tempo da animação da explosão)
            Destroy(gameObject,0.5f); //destruir disparo depois de 0.5s (tempo da animação da explosão)
            Destroy(colisor.gameObject); // destruir a lança
        }
        if (colisor.gameObject.CompareTag("skillExplosao")){
            GetComponent<Collider2D>().enabled = false;   //desativa o collider
            speed = 0; // pro tiro ficar parado
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f); //destruir esplosaõ depois de 0.5s (tempo da animação da explosão)
            Destroy(gameObject,0.5f); //destruir disparo depois de 0.5s (tempo da animação da explosão)
            Destroy(colisor.gameObject); // destruir a lança
        }
    }

    
}