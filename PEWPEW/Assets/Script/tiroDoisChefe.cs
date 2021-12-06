using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroDoisChefe : MonoBehaviour
{   
    public float speed;
    public GameController controller;
    public Animator animState;
    public bool spawned = false;
    private RectTransform player;
    private RectTransform tiroPosition;
    private Vector2 direcaoPlayer;
    
    void Start(){
        controller = FindObjectOfType<GameController>();
        StartCoroutine(animationTiro());
        tiroPosition = GetComponent<RectTransform>();
    }

    
    void Update(){
        
        if (spawned == true){
            
            tiroPosition.localPosition = Vector2.MoveTowards(tiroPosition.localPosition, (Vector2)tiroPosition.localPosition + direcaoPlayer, (speed) * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        if (colisor.gameObject.CompareTag("player")){
            controller.lifeLose -=1;
            Destroy(gameObject);
        }
        // destruir o objeto se ele chegar nos limites da fase
        if ((colisor.gameObject.CompareTag("costa")) || (colisor.gameObject.CompareTag("cima")) || (colisor.gameObject.CompareTag("baixo")) || (colisor.gameObject.CompareTag("frente"))){
            Destroy(gameObject, 1f);
        }
        
    }
    IEnumerator animationTiro(){

        animState.SetInteger("transition", 0); // animação de aparecer o tiro
        yield return new WaitForSecondsRealtime(0.5f); //espera primeira animação acabar
        animState.SetInteger("transition", 1); // começa animação de brilho do tiro 

        spawned = true; //confirma que foi feito a primeira animação
        player = GameObject.FindGameObjectWithTag("player").GetComponent<RectTransform>(); // pegar a cordenada do objeto
        direcaoPlayer = (player.localPosition - tiroPosition.localPosition).normalized; // pega vetor direção em relação do tipo-pra posição capturada do player
    
        yield return new WaitForSecondsRealtime(10f); // espera 10s pra não atualizar a posição do player, para não ficar seguindo ele 
    }
}
