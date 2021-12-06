using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{   
    public GameController controller;
    public Sprite fiveLife;
    public Sprite fourLife;
    public Sprite threeLife;
    public Sprite twoLife;
    public Sprite oneLife;
    public Sprite noLife;
    // Update is called once per frame
    void Update()
    {
        if (controller.lifeLose == 5){
            gameObject.GetComponent<SpriteRenderer>().sprite = fiveLife;
        }
        if (controller.lifeLose == 4){
            gameObject.GetComponent<SpriteRenderer>().sprite = fourLife;
        }
        if (controller.lifeLose == 3){
            gameObject.GetComponent<SpriteRenderer>().sprite = threeLife;
        }
        if (controller.lifeLose == 2){
            gameObject.GetComponent<SpriteRenderer>().sprite = twoLife;
        }
        if (controller.lifeLose == 1){
            gameObject.GetComponent<SpriteRenderer>().sprite = oneLife;
        }
        if (controller.lifeLose == 0){
            gameObject.GetComponent<SpriteRenderer>().sprite = noLife;
        }
    }
}
