using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManager : MonoBehaviour
{
    public GameObject[] obstacles;
    
    
    public float start = 0;
    public float speed = 250;


    void respawnPlane(){
        transform.position += new Vector3(0,0,3000);
        foreach (var o in obstacles)
        {
            int newX = Random.Range(-80, 80);
            int newZ = Random.Range(1600, 2900);
            o.transform.position = new Vector3(newX, -30, newZ);
        }
    }

    void Update()
    {   
        transform.position -= new Vector3(0,0,1) * speed * Time.deltaTime;
        if (transform.position[2] < -800) respawnPlane();
    }

    void Start()
    {
        start = transform.position[2];
    }
}
