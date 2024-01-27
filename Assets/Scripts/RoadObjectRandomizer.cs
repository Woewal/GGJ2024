using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectRandomizer : MonoBehaviour
{
    GameObject RoadManagerObject;
    public GameObject[] Obstacles;
    public float speed = 250;
    const int spawningObstaclesCount = 10;

    public List<GameObject> spawnedObstacles;

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
        if (spawnedObstacles != null)                                                                            {
            foreach (var o in spawnedObstacles)                  {
                spawnedObstacles.Remove(o);
                Destroy(o);
            }
        }

        transform.position += new Vector3(0, 0, roadDepthSize * totalRoads * scaling);

        for (int i = 0; i < spawningObstaclesCount; i++)
        {
            GameObject randomObstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            float newX = Random.Range(-roadWidth * 0.8f, roadWidth * 0.8f);
            float newZ = Random.Range(roadDepthSize * 0.6f, roadDepthSize * 1.4f);
            Vector3 randomPosition = new Vector3(newX, 0, newZ);
            Quaternion randomAngle = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            GameObject newSpawn = Instantiate(randomObstacle, randomPosition, randomAngle, this.gameObject.transform);
            spawnedObstacles.Add(newSpawn);
        }

    }

    void Update()
    {
        transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        // if (spawnedObstacles != null) {
        //     foreach(var o in spawnedObstacles) {
        //         o.transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        //     } 
        // }

        if (transform.position.z < (-roadDepthSize * scaling))
        {
            RespawnPlane();
        }
    }
}
