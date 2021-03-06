using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dificuldadeInimigo1 : MonoBehaviour
{
    public GameController controller;
    public GameObject anotherSpawn;
    public int maxSpawn;
    public GameObject[] spawn;
    private bool did = false; // confere se ja fez a alteração de dificuldade dessa "troca de fase" 

    void Start(){
        
        controller = FindObjectOfType<GameController>();
    }

    void Update(){

        spawn = GameObject.FindGameObjectsWithTag("spawn1"); // faz vetor com todos os spawn 1 presente na cena
        if ((controller.Score != 0) && (controller.Score != 1) && (GameObject.FindWithTag("spawnBoss") == null) && (GameObject.FindWithTag("avisoBoss") == null) && (controller.Score % 50 == 1) && (spawn.Length < maxSpawn ) && (did == false)){ // resto da divisão por 50 tem ter resto 1, que seria o patamar de chegar ao chefe + 1 ponto por ter derrotado o mesmo, crescer até no maximo 3 spawn
            StartCoroutine(newSpawn());
            
            
        }
        
    }

    IEnumerator newSpawn(){
        
        did = true;
        GameObject newAnotherSpawn = Instantiate(anotherSpawn);
        newAnotherSpawn.transform.parent = transform;
        newAnotherSpawn.transform.position = transform.position + new Vector3(1.18f,-0.41f,0); // posiciona o spawn no mesmo lugar que o outro spawn
        newAnotherSpawn.GetComponent<spawnInimigo>().maxTime += 0.5f;

        yield return new WaitForSecondsRealtime(30.0f); // espera 30 segundo pra confirma que faça +1 ponto, para não criar mais de um spawn por vez
        did = false;
    }
}
