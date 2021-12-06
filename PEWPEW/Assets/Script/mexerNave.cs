using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mexerNave : MonoBehaviour
{
    public float speed;
    public bool pause = false;
    public GameObject GamerOver;
    public GameObject Pause;
    public Text pauseText;
    public GameController controller;
    public GameObject habilidadeUm;
    public float timerSkill; // cooldown skill de explosão
    public GameObject habilidadeDois;
    public float timerSkillDois; // cooldown skill de escudo
    public float xAtual; // controlar valor de X para não atravessar o "limite" da direita
    public float yAtual; // controlar valor de y para não atravessar o "limite" de cima e de baixo

    void Start(){
        controller = FindObjectOfType<GameController>();
        timerSkill = 20f;
        timerSkillDois = 20f;
    }
    // Update is called once per frame
    void Update()
    {   
        xAtual = GetComponent<Transform>().position.x;
        yAtual = GetComponent<Transform>().position.y;
        timerSkill += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Escape)) && (Time.timeScale != 0)){ // Esc pausa o jogo
            Pause.SetActive(true);
            pauseText.text = ("Jogo Pausado");
            Time.timeScale = 0;
            pause = true;
        }else if((Input.GetKeyDown(KeyCode.Escape)) && (pause == true)){ // Despausar o jogo
                Time.timeScale = 1;
                Pause.SetActive(false);
                pause = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift)){ // shift aumenta velocidade
            speed += 4;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){ // shift aumenta velocidade
            speed -= 4;

        }
        if ((Input.GetKey(KeyCode.Q)) && (timerSkill > 20f)){
            GameObject newhabilidadeUm = Instantiate(habilidadeUm);
            newhabilidadeUm.transform.position = transform.position;
            timerSkill = 0;
        }

        timerSkillDois += Time.deltaTime;
        if ((Input.GetKey(KeyCode.E)) && (timerSkillDois > 20f)){
            GameObject newhabilidadeDois = Instantiate(habilidadeDois);
            newhabilidadeDois.transform.position = transform.position + new Vector3(2f,0,0);
            timerSkillDois = 0;
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
        if (colisor.gameObject.CompareTag("chefe")){
            controller.lifeLose = 0;

        }
        
    }

    public void Despausar(){
        Time.timeScale = 1;
        Pause.SetActive(false);
        pause = false;
    }

       
}
