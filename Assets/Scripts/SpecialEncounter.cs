using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEncounter : MonoBehaviour
{
    public GameObject scoreManagerObject;
    [SerializeField]
    private int startPointEncounter = 50;
    [SerializeField]
    private int differenceBetweenEncounter = 50;

    private int startPointTrain = 75;

    public GameObject Truck;
    public GameObject Train;

    public void ScoreChecker(int score)
    {
        Debug.Log("Score is: " + score);
        if(score >= startPointEncounter)
        {
            startPointEncounter += differenceBetweenEncounter;
            TruckEncounter();
        }
        if(score >= startPointTrain)
        {
            startPointTrain += differenceBetweenEncounter;
            TrainEncounter();
        }
    }

    void TruckEncounter()
    {
        Truck.SetActive(true);
    }

    void TrainEncounter()
    {
        Train.SetActive(true);
    }
}
