using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoInimigo3 : MonoBehaviour
{
    public float speed;
    public GameController controller;
    public GameObject explosao;
    private Transform player;
    


    // Start is called before the first frame update
    void Start(){
        controller = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        
        
    }

    // Update is called once per frame
    void Update(){
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, (speed) * Time.deltaTime);
        if (Time.timeScale == 1){
            transform.Rotate (0, 0, 0.5f, Space.Self );
        }
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        
        if (colisor.gameObject.CompareTag("lanca")){ // se pegar na lanca
            
            Destroy(gameObject);
            Destroy(colisor.gameObject);
            if (GameObject.FindGameObjectWithTag("chefe") == false){
                controller.Score += 1;
                controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;
            }
            
            
            GameObject newExplosao = Instantiate(explosao);
            newExplosao.transform.position = transform.position + new Vector3(0,0,0);
            Destroy(newExplosao, 0.5f);
        }
        if (colisor.gameObject.CompareTag("skillExplosao")){ // se pegar no poder de explosão
            
            Destroy(gameObject);
            if (GameObject.FindGameObjectWithTag("chefe") == false){
                controller.Score += 1;
                controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ;
            }

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


}
