using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public float maxTime;
    public float height;
    public float positionX;
 
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if  (timer > maxTime){
            GameObject newPowerUp = Instantiate(powerUp);
            newPowerUp.transform.position = transform.position + new Vector3(Random.Range(-positionX,positionX), Random.Range(-height,height),0);
            timer = 0;
        }

        timer += Time.deltaTime;
    }


    
}