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

    public GameObject Truck;

    public void ScoreChecker(int score)
    {
        Debug.Log("Score is: " + score);
        if(score >= startPointEncounter)
        {
            startPointEncounter += differenceBetweenEncounter;
            TruckEncounter();
        }
    }

    void TruckEncounter()
    {
        Truck.SetActive(true);
    }
}
