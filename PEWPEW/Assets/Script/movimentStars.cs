using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentStars : MonoBehaviour
{
     public float speed;

   
    // Update is called once per frame
    void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, 8f);       
    }
}