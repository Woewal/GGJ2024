using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject Road;
    [SerializeField]
    private int amountOfRoads = 2;
    public List<GameObject> Roads;
    private float startPoint;
    public float distanceBetweenRoads;
    public float defaultRoadSize = 75;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfRoads; i++)
        {
            GameObject tempRoad =  Instantiate(Road, gameObject.transform);
            Roads.Add(tempRoad);
        }

        startPoint = 0;
        distanceBetweenRoads = Roads[0].transform.localScale.x;
        foreach (var road in Roads)
        {
            road.transform.position = new Vector3(0, 0, startPoint);
            startPoint += distanceBetweenRoads * defaultRoadSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
