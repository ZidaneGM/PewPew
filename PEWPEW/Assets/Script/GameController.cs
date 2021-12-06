using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int Score;
    public Text scoreText;
    public Text gOverText;
    public Text lifeText;
    public int lifeLose = 5; // contador de vida
    public GameObject GamerOver;
    public GameObject Chefe; // spawn do chefe
    public GameObject inimigos; // spawn dos inimigos
    public GameObject avisoBoss; // aviso de chefe
    public GameObject spawnDois; // ativar spawn do inimigo 2 quando derrota o chefe a primeira vez
    public chefeUm chefe; // chefe propriamente dito
    public Animator animState;
    public bool bossAlive = false; //saber se o boss morreu para ativar animação base 
    public bool activeDanger = false;

    
    
    
    void Start(){
        Time.timeScale = 1;
        chefe = FindObjectOfType<chefeUm>();
    }

    void Update(){
        if (lifeLose < 1){
            lifeLose = 0;
        } else if (lifeLose > 5){
            lifeLose = 5;
        }

        if (lifeLose < 1){ //se zerar as vida termina o jogo
            confereScore(Score);
            GamerOver.SetActive(true);
            gOverText.text = ("Eles dominaram tudo sem voce perceber");
            Time.timeScale = 0;
        }

        if(( Score != 0 && Score % 50 == 0)){  //diferente de 0 e divisivel por 50
            
            StartCoroutine(pointBoss());
            if ((GameObject.FindWithTag("avisoBoss") == null) && (GameObject.FindWithTag("spawnBoss") == null) && (activeDanger == false)){
                StartCoroutine(avisarBoss()); 
            }                     
            
            
            

        }
        if (Score > 50){
            spawnDois.SetActive(true);

        }
        
        if (bossAlive == true){
            animState.SetInteger("bgState", 0); // ativa bg normal
            bossAlive = false;
        }
    }
      
    public void quit(){
        Application.Quit();
    }
    public void chanceScene(string nome){
        SceneManager.LoadScene(nome);
    }
    public void RestartGame(string fase){
        SceneManager.LoadScene(fase);
        lifeLose = 5;
    }

    public void confereScore(int score){
        if (score > valoresHighscore.top1){
            //valoresHighscore.top1 = score;
            PlayerPrefs.SetInt ("top1", score); // setar valor no top 
            PlayerPrefs.SetInt ("top2", valoresHighscore.top1); // ajustar posição dos outros top
            PlayerPrefs.SetInt ("top3", valoresHighscore.top2); // ajustar posição dos outros top
            PlayerPrefs.SetInt ("top4", valoresHighscore.top3); // ajustar posição dos outros top
            PlayerPrefs.SetInt ("top5", valoresHighscore.top4); // ajustar posição dos outros top
        }else if ((score > valoresHighscore.top2) && (score <= valoresHighscore.top1)){
                //valoresHighscore.top2 = score;
                PlayerPrefs.SetInt ("top2", score); // setar valor no top 
                PlayerPrefs.SetInt ("top3", valoresHighscore.top2); // ajustar posição dos outros top
                PlayerPrefs.SetInt ("top4", valoresHighscore.top3); // ajustar posição dos outros top
                PlayerPrefs.SetInt ("top5", valoresHighscore.top4); // ajustar posição dos outros top
        }else if ((score > valoresHighscore.top3) && (score <= valoresHighscore.top2)){
                //valoresHighscore.top3 = score;
                PlayerPrefs.SetInt ("top3", score); // setar valor no top 
                PlayerPrefs.SetInt ("top4", valoresHighscore.top3); // ajustar posição dos outros top
                PlayerPrefs.SetInt ("top5", valoresHighscore.top4); // ajustar posição dos outros top
        }else if ((score > valoresHighscore.top4) && (score <= valoresHighscore.top3)){
                //valoresHighscore.top4 = score;
                PlayerPrefs.SetInt ("top4", score); // setar valor no top 
                PlayerPrefs.SetInt ("top5", valoresHighscore.top4); // ajustar posição dos outros top
        }else if ((score > valoresHighscore.top5) && (score <= valoresHighscore.top4)){
                //valoresHighscore.top5 = score;
                PlayerPrefs.SetInt ("top5", score); // setar valor no top 
        }
    }

    IEnumerator pointBoss(){
        
        inimigos.SetActive(false); // desativa spawn dos outro inimigos
        
        if(GameObject.FindWithTag("spawnBoss") == null){ // caso o chefe ja estaja em cena poder criar um inimigo sem ele ser destruido automaticamente
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("inimigo");//destruir todos inimigos q estejam na cena
            for(int i=0; i< enemies.Length; i++){
                Destroy(enemies[i]);
            }
            GameObject[] enemiesB = GameObject.FindGameObjectsWithTag("inimigoB");//destruir todos inimigos q estejam na cena
            for(int i=0; i< enemiesB.Length; i++){
                Destroy(enemiesB[i]);
            }
        } 
        yield return new WaitForSecondsRealtime(4.2f);
        Chefe.SetActive(true); // ativa spawn do mestre
    }

    IEnumerator avisarBoss(){

        avisoBoss.SetActive(true);
        activeDanger = true;
        yield return new WaitForSecondsRealtime(10f); // so criar esse objeto uma vez
        activeDanger = false;
        

    }

    


}

