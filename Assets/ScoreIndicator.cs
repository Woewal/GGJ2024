using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    int highestScore;

    public GameObject SpecialEncounterObject;


    private void Start()
    {
        highestScore = Highscore.GetHighestScore();

        UpdateScore(0);

        ScoreManager.Instance.OnScoreChange += UpdateScore;
    }

    private void UpdateScore(int amount)
    {
        ScoreText.text = "Score: " + amount.ToString() + "\n" + "Highest score: " + highestScore;
        if (SpecialEncounterObject != null) SpecialEncounterObject.GetComponent<SpecialEncounter>().ScoreChecker(amount);
    }
}
