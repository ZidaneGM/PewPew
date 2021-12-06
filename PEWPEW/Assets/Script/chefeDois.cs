using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chefeDois : MonoBehaviour
{
    public bool up; // funciona com um "subir?"
    public bool right; // funciona com um "ir pra direita?"
    public float yAtual;
    public float xAtual;
    public float speed;
    public int vida = 15;
    public GameController controller;
    public GameObject explosao;
    public GameObject obst;
    public float maxTime;
    public Scene cenaAtual;
    private float timer = 0f;
    public GameObject obstShield; 
    public float maxTimeShield;
    private float timerShield = 0f;
    

    void Start(){   

       
        yAtual = GetComponent<Transform>().position.y; // pega valor Y da posição inicial do inimigo
        xAtual = GetComponent<Transform>().position.x; // pega valor x da posição inicial do inimigo
        controller = FindObjectOfType<GameController>();
        
        if (yAtual > 0){  // diz se ele vai subir ou descer
            up = false;
        }else{
            up = true;
        }
        
    }

    void Update(){
        
        movimentacaoVertical();

        if(vida < 6){ //se vida chegar a menos de 6 começa a andar horizontalmente
            movimentacaoHorizontal();
        }

        if (vida < 1){
            vida = 0;
        }

        if  ((timer > maxTime) && (vida > 0)){ // criar tiro
            GameObject newObst = Instantiate(obst);
            newObst.transform.position = transform.position + new Vector3(-0.6f,-0.5f,0);
            timer = 0;
        }

        timer += Time.deltaTime;

        if  ((timerShield > maxTimeShield) && (vida > 0)){ // criar escudo
            GameObject newObstShield = Instantiate(obstShield);
            newObstShield.transform.position = transform.position + new Vector3(-0.6f,-0.5f,0);
            timerShield = 0;
        }

        timerShield += Time.deltaTime;
                
    }

    void OnTriggerEnter2D(Collider2D colisor){
        if (colisor.gameObject.CompareTag("lanca")){
            Destroy(colisor.gameObject);
            if(vida < 1){
                StartCoroutine(morteChefe()); //inicia a corrotina de morte do mestre
            }
        }
        
        
    }


    void movimentacaoVertical(){
        yAtual = GetComponent<Transform>().position.y; // pega valor Y atual a cada execução
        if ((up == false) && (yAtual < -3)){  // se chegar na borda de baixo up recebe true 
            up = true;
        }
        if ((up == true) && (yAtual > 3)){ // se chegar na borda de cima up recebe false 
            up = false;
        }

        if (up == true){
            transform.position += Vector3.up * speed * Time.deltaTime;  // se up tiver true ele sobe
        }else{
            transform.position += Vector3.down * speed * Time.deltaTime; // se up tiver false ele desce
        }
    }

    void movimentacaoHorizontal(){
        xAtual = GetComponent<Transform>().position.x; // pega valor Y atual a cada execução
        if ((right == false) && (xAtual < 1.3)){  // se chegar na borda da esquerda right recebe true 
            right = true;
        }
        if ((right == true) && (xAtual > 6f)){ // se chegar na borda de direita right recebe false 
            right = false;
        }

        if (right == true){
            transform.position += Vector3.right * speed * Time.deltaTime;  // se up tiver true ele sobe
        }else{
            transform.position += Vector3.left * speed * Time.deltaTime; // se up tiver false ele desce
        }
    }

    IEnumerator morteChefe(){

        controller.Score += 1; // da 1 pontos quando ganhar o chefe
        controller.scoreText.text = controller.Score.ToString().PadLeft( 4 , '0') ; // atualiza quantidade de ponto
        
        
        GetComponent<Collider2D>().enabled = false;   //desativa o collider
        GetComponent<AudioSource>().Play();
        speed = 0; // pro chefe ficar parado
        GameObject newExplosao = Instantiate(explosao);
        newExplosao.transform.position = transform.position + new Vector3(0,0,0);
        Destroy(GameObject.FindGameObjectWithTag("inimigo")); //destruir inimigos q estejam na cena
        
        
        Destroy(newExplosao, 1.4f); // explode em 1.4s e desativao sprite depois desse tempo
        yield return new WaitForSecondsRealtime(1.4f); 
        GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
        
        yield return new WaitForSecondsRealtime(5f); // esperar 5 segundo e meio pra não repitir a ação antes de destruir o chefe
        if (cenaAtual.name == "jogo"){ // Compara se esta na cena "jogo"
            controller.inimigos.SetActive(true); // ativa spawn dos outro inimigos
            controller.Chefe.SetActive(false); // desativa spawn do mestre
            controller.bossAlive = true;
        }
        Destroy(GameObject.FindGameObjectWithTag("chefe")); //destruir o chefe
    }

}