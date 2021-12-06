using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valoresHighscore : MonoBehaviour
{
    public static int top1;
    public static int top2;
    public static int top3;
    public static int top4;
    public static int top5;
    private GameObject[] datas;

    void Awake(){
        datas = GameObject.FindGameObjectsWithTag("data"); // impedir que crie varios objetos desse, ao voltar e sair do menu
        if (datas.Length >= 2){
            Destroy(datas[0]);
        }

        DontDestroyOnLoad(gameObject); //n destruir o objeto ao trocar de cena
        top1 = PlayerPrefs.GetInt ("top1");
        top2 = PlayerPrefs.GetInt ("top2");
        top3 = PlayerPrefs.GetInt ("top3");
        top4 = PlayerPrefs.GetInt ("top4");
        top5 = PlayerPrefs.GetInt ("top5");
    }
    
}
