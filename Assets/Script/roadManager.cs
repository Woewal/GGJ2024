using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManager : MonoBehaviour
{
    public GameObject[] obstacles;
    
    public float start = 0;
    public float speed = 100;


    void respawnPlane(){
        transform.position += new Vector3(0,0,3000);
        foreach (var o in obstacles)
        {
            o.transform.position = new Vector3(Random.Range(-80, 80), -30, Random.Range(1600, 2900));
        }
    }

    void Update()
    {   
        transform.position -= transform.forward * speed * Time.deltaTime;
        foreach (var o in obstacles) {
         o.transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (transform.position[2] < -800) respawnPlane();
    }

    void Start()
    {
        start = transform.position[2];
    }
}
