using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{

    public GameController controller;

    void Start(){
        StartCoroutine(skil());
        
    }

    IEnumerator skil(){
        yield return new WaitForSecondsRealtime(0.2f); //espera 1 segundos 
        gameObject.GetComponent<CircleCollider2D>().radius += 0.3f; 
        yield return new WaitForSecondsRealtime(0.2f); //espera 1 segundos
        gameObject.GetComponent<CircleCollider2D>().radius += 0.4f;
        yield return new WaitForSecondsRealtime(0.2f); //espera 1 segundos
        gameObject.GetComponent<CircleCollider2D>().radius += 0.4f;
        yield return new WaitForSecondsRealtime(0.2f); //espera 1 segundos
        gameObject.GetComponent<CircleCollider2D>().radius += 0.5f;
        GetComponent<CircleCollider2D>().enabled = false;   //desativa o collider 
        GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite
        Destroy(gameObject, 2f);
    }
}
