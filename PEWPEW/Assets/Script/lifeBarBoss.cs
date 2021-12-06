using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeBarBoss : MonoBehaviour
{
    public float vida;
    public Texture Sangue,Contorno;    
    public chefeUm chefe;
    public chefeDois chefe2;

    void Start (){
        chefe  = FindObjectOfType<chefeUm>();
        chefe2 = FindObjectOfType<chefeDois>();
        if (GameObject.FindObjectOfType<chefeUm>() == null){
            vida = chefe2.vida;
        } else {
            vida = chefe.vida;
        }
    }
    void Update (){
        if (GameObject.FindObjectOfType<chefeUm>() == null){
            vida = chefe2.vida;
        } else {
            vida = chefe.vida;
        }
    }

    void OnGUI (){
    GUI.DrawTexture (new Rect (Screen.width / 1.34f, Screen.height / 1.6f, Screen.width / 3.99f/15*vida, Screen.height / 1.5f), Sangue);
    GUI.DrawTexture (new Rect (Screen.width / 1.34f, Screen.height / 1.6f, Screen.width / 4, Screen.height / 1.5f), Contorno);
    }
}
