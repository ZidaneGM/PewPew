using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnInimigo : MonoBehaviour
{
    public GameObject obst;
    public float maxTime;
    public float height;
 
    private float timer = 0f;

    void Start()
    {
        GameObject newObst = Instantiate(obst);
        newObst.transform.position = transform.position + new Vector3(0, Random.Range(-height,height),0);
    }

    // Update is called once per frame
    void Update()
    {
        if  (timer > maxTime){
            GameObject newObst = Instantiate(obst);
            newObst.transform.position = transform.position + new Vector3(0, Random.Range(-height,height),0);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}