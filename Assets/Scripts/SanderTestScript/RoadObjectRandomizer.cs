using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectRandomizer : MonoBehaviour
{
    GameObject RoadManagerObject;
    public GameObject[] Obstacles;
    public float speed = 250;

    private int totalRoads;
    private float scaling;
    private float roadDepthSize;
    private float roadWidth;

    private void Start()
    {
        RoadManagerObject = gameObject.transform.parent.gameObject;
        UpdateRoads();
    }

    void UpdateRoads()
    {
        totalRoads = RoadManagerObject.GetComponent<RoadManager>().Roads.Count;
        scaling = RoadManagerObject.GetComponent<RoadManager>().distanceBetweenRoads;
        roadDepthSize = RoadManagerObject.GetComponent<RoadManager>().defaultRoadSize;
        roadWidth = roadDepthSize / 7.5f;
    }

    void RespawnPlane()
    {
        
        transform.position += new Vector3(0, 0, roadDepthSize * totalRoads * scaling);
        foreach (var o in Obstacles)
        {
            float newX = Random.Range(-roadDepthSize * 0.8f, roadDepthSize * 0.8f);
            float newZ = Random.Range(roadDepthSize * 1.1f, roadDepthSize * 1.9f);
            o.transform.position = new Vector3(newX, 0, newZ);
        }
    }

    void Update()
    {
        transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        if (transform.position.z < (-roadDepthSize * scaling)) RespawnPlane();
    }
}
