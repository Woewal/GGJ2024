using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    private ScoreManager ScoreManager;

    public Image BarImage;

    public Gradient Gradient;

    private void OnEnable()
    {
        ScoreManager = ScoreManager.Instance;

        ScoreManager.OnRatingChange += UpdateBarImage;
    }

    private void OnDisable()
    {
        ScoreManager.OnRatingChange -= UpdateBarImage;
    }

    private void UpdateBarImage(float amount)
    {
        var percentage = amount / ScoreManager.MaxRating;

        BarImage.color = Gradient.Evaluate(percentage);

        BarImage.fillAmount = percentage;
    }
}
