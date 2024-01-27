using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChange += (amount) => { ScoreText.text = amount.ToString(); };
    }
}
