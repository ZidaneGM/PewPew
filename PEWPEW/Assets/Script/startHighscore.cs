using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startHighscore : MonoBehaviour
{   
    public Text posicaoUm;
    public Text posicaoDois;
    public Text posicaoTres;
    public Text posicaoQuatro;
    public Text posicaoCinco;
    
    // Start is called before the first frame update
    void Start()
    {
        posicaoUm.text     = valoresHighscore.top1.ToString().PadLeft( 4 , '0');
        posicaoDois.text   = valoresHighscore.top2.ToString().PadLeft( 4 , '0');
        posicaoTres.text   = valoresHighscore.top3.ToString().PadLeft( 4 , '0');
        posicaoQuatro.text = valoresHighscore.top4.ToString().PadLeft( 4 , '0');
        posicaoCinco.text  = valoresHighscore.top5.ToString().PadLeft( 4 , '0');
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void chanceScene(string nome){
        SceneManager.LoadScene(nome);
    }
    public void zerarHighScore(){
        PlayerPrefs.SetInt ("top1", 0);
        PlayerPrefs.SetInt ("top2", 0);
        PlayerPrefs.SetInt ("top3", 0);
        PlayerPrefs.SetInt ("top4", 0);
        PlayerPrefs.SetInt ("top5", 0);
        valoresHighscore.top1 = PlayerPrefs.GetInt ("top1");
        valoresHighscore.top2 = PlayerPrefs.GetInt ("top2");
        valoresHighscore.top3 = PlayerPrefs.GetInt ("top3");
        valoresHighscore.top4 = PlayerPrefs.GetInt ("top4");
        valoresHighscore.top5 = PlayerPrefs.GetInt ("top5");
        posicaoUm.text     = valoresHighscore.top1.ToString().PadLeft( 4 , '0');
        posicaoDois.text   = valoresHighscore.top2.ToString().PadLeft( 4 , '0');
        posicaoTres.text   = valoresHighscore.top3.ToString().PadLeft( 4 , '0');
        posicaoQuatro.text = valoresHighscore.top4.ToString().PadLeft( 4 , '0');
        posicaoCinco.text  = valoresHighscore.top5.ToString().PadLeft( 4 , '0');
    }
}
