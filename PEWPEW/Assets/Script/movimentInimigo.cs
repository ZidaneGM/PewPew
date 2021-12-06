using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentInimigo : MonoBehaviour
{
    public float speed;
    public GameController controller;
    public GameObject explosao;

    void Start(){
        controller = FindObjectOfType<GameController>();
        
    }
    // Update is called once per frame
    void Update(){  
        transform.position += Vector3.left * speed * Time.deltaTime; 

    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("skillExplosao")){ // se pegar no poder de explosão
            
            Destroy(gameObject);
            controller.Score += 1;
            controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;
            
            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);
        }

        if (col.gameObject.CompareTag("costa")){
            Destroy(gameObject);
        }
        if ((col.gameObject.CompareTag("inimigo")) || (col.gameObject.CompareTag("limitSpawn"))){
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("lanca")){ // se pegar na lanca
            GetComponent<Collider2D>().enabled = false;   //desativa o collider 
            GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
            Destroy(gameObject, 2f);
            Destroy(col.gameObject);
            controller.Score += 1;
            controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;
            
            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);
            }


        if (col.gameObject.CompareTag("player")){
            Destroy(gameObject);
            controller.lifeLose -=1;
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);

        }
    }
}