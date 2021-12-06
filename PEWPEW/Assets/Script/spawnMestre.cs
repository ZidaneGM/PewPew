using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMestre : MonoBehaviour
{ 
    public GameObject chefeUm;
    public GameObject chefeDois;
    public int lastBoss = 2;
    public float height;
    public Animator animState;
 
    

    void Start(){
        

        if (lastBoss == 2){
        animState.SetInteger("bgState", 2); // ativa bg do chefe um 
        spawnarBoss(chefeUm);
        lastBoss = 1;
        } else if (lastBoss == 1){
            animState.SetInteger("bgState", 1); // ativa bg do chefe dois
            spawnarBoss(chefeDois);
            lastBoss = 2;            
        }
        
    }
    void Update(){
        if (GameObject.FindWithTag("chefe") == null){ // se o chefe não estiver na cena invoca o chefe
            if (lastBoss == 2){ 
                animState.SetInteger("bgState", 2); // ativa bg do chefe um 
                spawnarBoss(chefeUm);
                lastBoss = 1;
            } else if (lastBoss == 1){
                animState.SetInteger("bgState", 1); // ativa bg do chefe dois
                spawnarBoss(chefeDois);
                lastBoss = 2;            
                }
        }    
    }

    public void spawnarBoss(GameObject chefe){
        GameObject newChefe = Instantiate(chefe);
        newChefe.transform.position = transform.position + new Vector3(0, Random.Range(-height,height),0);
    }    
    
}