using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentInimigo2 : MonoBehaviour
{
     public bool up;
     public float yAtual;
     public float speed;
     public GameController controller;
     public GameObject explosao;
    // Start is called before the first frame update
    void Start()
    {   
        yAtual = GetComponent<Transform>().position.y; // pega valor Y da posição inicial do inimigo
        controller = FindObjectOfType<GameController>();
        if (yAtual > 0){  // diz se ele vai subir ou descer
            up = false;
        }else{
            up = true;
        }
        
    }

    // Update is called once per frame
    void Update(){

        movimentacaoVertical();
        
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("lanca")){ // se pegar na lanca
            
            GetComponent<Collider2D>().enabled = false;   //desativa o collider 
            GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
            Destroy(gameObject);
            Destroy(colisor.gameObject);
            controller.Score += 1;
            controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;
            
            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);
        }
        if (colisor.gameObject.CompareTag("skillExplosao")){ // se pegar no poder de explosão
            
            Destroy(gameObject);
            controller.Score += 1;
            controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;

            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);
        }
        if (colisor.gameObject.CompareTag("player")){
            Destroy(gameObject);
            controller.lifeLose -=1;
            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);

        }
    }

    void movimentacaoVertical(){
        yAtual = GetComponent<Transform>().position.y; // pega valor Y atual a cada execução
        if ((up == false) && (yAtual < -3.6)){  // se chegar na borda de baixo up recebe true 
            up = true;
        }
        if ((up == true) && (yAtual > 3.3f)){ // se chegar na borda de cima up recebe false 
            up = false;
        }

        if (up == true){
            transform.position += Vector3.up * speed * Time.deltaTime;  // se up tiver true ele sobe
        }else{
            transform.position += Vector3.down * speed * Time.deltaTime; // se up tiver false ele desce
        }
    }
}
