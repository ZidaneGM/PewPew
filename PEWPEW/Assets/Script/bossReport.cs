using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossReport : MonoBehaviour
{
    public string tipo;
    public GameObject avisoBoss; // aviso de chefe
    public bool activeDanger = false;

    void Update(){ 

        if (activeDanger == false){
        StartCoroutine(piscarDanger(tipo));
        }
            
    }

    IEnumerator piscarDanger(string tipo){
       
            activeDanger = true;

            for (int i = 0; i < 6; i++)
            if (tipo == "image"){
                GetComponent<Image>().enabled = false; // desativa o fundo do aviso
                yield return new WaitForSecondsRealtime(0.3f);
                GetComponent<Image>().enabled = true; // ativa o fundo do aviso
                yield return new WaitForSecondsRealtime(0.3f);
                GetComponent<Image>().enabled = false; // desativa o fundo do aviso

            } else if (tipo == "texto"){
                GetComponent<Text>().enabled = false; // desativa o texto do aviso
                yield return new WaitForSecondsRealtime(0.3f);
                GetComponent<Text>().enabled = true; // desativa o texto do aviso
                yield return new WaitForSecondsRealtime(0.3f);
                GetComponent<Text>().enabled = false; // desativa o texto do aviso

            }
            
            yield return new WaitForSecondsRealtime(5f); // evitar que se ative novamente
            activeDanger = true;
            avisoBoss.SetActive(false);
        
    }
}
