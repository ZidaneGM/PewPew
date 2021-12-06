using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar : MonoBehaviour
{
    public GameObject obst;
    public float maxTime;
 
    private float timer = 0f;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        GameObject newObst = Instantiate(obst);
        newObst.transform.position = transform.position + new Vector3(0,0,0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (timer > maxTime){
            GetComponent<AudioSource>().Play();
            GameObject newObst = Instantiate(obst);
            newObst.transform.position = transform.position + new Vector3(0,0,0);
            

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
