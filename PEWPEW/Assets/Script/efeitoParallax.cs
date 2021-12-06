using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efeitoParallax : MonoBehaviour
{
    private float largura; //largura do sprite
    private float startPos; //posição inicial 
    private Transform cam;
    public float parallaxFactor; // velocidade de movimento de cada objeto
    // Start is called before the first frame update
    void Start(){
        startPos = transform.position.x;
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform; //recebe posição da camera principal
    }

    // Update is called once per frame
    void Update(){
        float reposi = cam.transform.position.x * (1 - parallaxFactor); // os elementos do bg se reposicionarem antes da camera chegar ao final
        float distance = cam.transform.position.x * parallaxFactor; // distancia da camera para os elementos

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(reposi > startPos + largura){
            startPos += largura;
        }else if(reposi < startPos - largura){
            startPos -= largura;
        }
    }
}
