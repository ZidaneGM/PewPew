using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gerenciarCenas : MonoBehaviour
{
    public void chanceScene(string nome){
        SceneManager.LoadScene(nome);
    }

    public void quit(){
        Application.Quit();
    }
}
