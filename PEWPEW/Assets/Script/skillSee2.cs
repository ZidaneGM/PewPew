using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillSee2 : MonoBehaviour
{
    public GameObject nave;
    private bool usable;
    private float skillTimer;

    void Start(){
            nave= GameObject.FindGameObjectWithTag("player");
    }
    void Update(){
        skillTimer=nave.GetComponent<mexerNave>().timerSkillDois;
        
        if(skillTimer > 20){
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        } else if (skillTimer < 20){
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        
    }
}