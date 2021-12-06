using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudoReflexivo : MonoBehaviour
{
    public GameObject tiro;
    // Start is called before the first frame update
    void Start(){
        StartCoroutine(reflexionShield());
    }

    void OnTriggerEnter2D(Collider2D colisor){
        
        
        if (colisor.gameObject.CompareTag("lanca")){
            GetComponent<AudioSource>().Play();
            tiro = GameObject.FindGameObjectWithTag("lanca");
            tiro.GetComponent<lanca_Tiro>().speed = tiro.GetComponent<lanca_Tiro>().speed * (-1);
            //colisor.gameObject.speed = colisor.gameObject.speed * (-1);
        }
        
    }

    IEnumerator reflexionShield(){
        yield return new WaitForSecondsRealtime(0.3f); //espera 1 segundos 
        transform.GetComponent<Collider2D>().GetComponent<BoxCollider2D>().size = new Vector2(0.1332903f,0.6008444f);
        //gameObject.GetComponent<BoxCollider2D>().size.y += 0.204171f; 
        yield return new WaitForSecondsRealtime(0.3f); //espera 1 segundos
        //transform.GetComponent<Collider>().GetComponent<BoxCollider>().offset = new Vector2(0f,-06159635f);
        transform.GetComponent<Collider2D>().GetComponent<BoxCollider2D>().size = new Vector2(0.1332903f,0.9947822f);
        //gameObject.GetComponent<BoxCollider2D>().offset.y -= 0.0006159635f;
        //gameObject.GetComponent<BoxCollider2D>().size.y += 0.3939378f; 
        yield return new WaitForSecondsRealtime(0.3f); //espera 1 segundos
        transform.GetComponent<Collider2D>().GetComponent<BoxCollider2D>().size = new Vector2(0.1332903f,1.50292f);
        //gameObject.GetComponent<BoxCollider2D>().size.y += 0.5081378f;
        Destroy(gameObject,0.3f); 
        
    }
}
