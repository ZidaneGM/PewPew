using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillEscudo : MonoBehaviour
{
    public float speed;
    public GameObject naveReference;
    public float xAtual; // controlar valor de X para não atravessar o "limite" da direita
    public float yAtual; // controlar valor de y para não atravessar o "limite" de cima e de baixo
    
    void Start(){
        Destroy(gameObject, 1f);
        naveReference= GameObject.FindGameObjectWithTag("player");
    }
    void Update(){

        xAtual = naveReference.GetComponent<Transform>().position.x;
        yAtual = naveReference.GetComponent<Transform>().position.y;
        
        if (Input.GetKeyDown(KeyCode.LeftShift)){ // shift aumenta velocidade
            speed += 4;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){ // shift aumenta velocidade
            speed -= 4;

        }

        if (Time.timeScale != 0){
            if ((Input.GetKey(KeyCode.D)) && (xAtual < 7f)){
                transform.position += Vector3.right * speed * Time.deltaTime; // mexer a nave
               
            }
            if ((Input.GetKey(KeyCode.A)) && (xAtual > -6.7f)){
                transform.position += Vector3.left * speed * Time.deltaTime;// mexer a nave
                
            }
            if ((Input.GetKey(KeyCode.W)) && (yAtual < 3.5f)){
                transform.position += Vector3.up * speed * Time.deltaTime;// mexer a nave
                
            }
            if ((Input.GetKey(KeyCode.S)) && (yAtual > -3.9f)){
                transform.position += Vector3.down * speed * Time.deltaTime;// mexer a nave
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        
        if ((colisor.gameObject.CompareTag("tiroInimigo")) || (colisor.gameObject.CompareTag("inimigo")) || (colisor.gameObject.CompareTag("inimigoB"))){
            Destroy(colisor.gameObject);
        }
        
    }
}
