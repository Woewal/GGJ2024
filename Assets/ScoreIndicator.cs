using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChange += (amount) => { 
            ScoreText.text = amount.ToString(); 
            transform.DOPunchScale(Vector3.one, 0.1f, 5, 1); 
        };
    }
}
