using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backup : MonoBehaviour
{   
    public float speed;
    public GameController controller;
    private float[] targetPlayer;
    public float targetX;
    public float targetY;
    public GameObject explosao;
    public Animator animState;
    public bool spawned = false;
    private Vector2 player;
    private Vector2 tiroPosition;
    
    void Start(){
        controller = FindObjectOfType<GameController>();
        StartCoroutine(animationTiro());
        
    }

    
    void Update(){
        
        player = new Vector2(targetX + 0.61f, targetY + 0.43783832f); // ajustar posição do sprite
        tiroPosition = gameObject.transform.position;
        if (spawned == true){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX + 0.61f, targetY + 0.43783832f), (speed) * Time.deltaTime);
            if (player.Equals(tiroPosition)){
                animState.SetInteger("transition", 2);
                Destroy(gameObject, 1f);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("player")){
            controller.lifeLose -=1;
            Destroy(gameObject);
        }
        
    }
    IEnumerator animationTiro(){

        animState.SetInteger("transition", 0); // animação de aparecer o tiro
        yield return new WaitForSecondsRealtime(0.5f); //espera primeira animação acabar
        animState.SetInteger("transition", 1); // começa animação de brilho do tiro 

        spawned = true; //confirma que foi feito a primeira animação
        targetX = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.x;
        targetY = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.y; // pega posição atual do player
        
        yield return new WaitForSecondsRealtime(10f);
    }
}
