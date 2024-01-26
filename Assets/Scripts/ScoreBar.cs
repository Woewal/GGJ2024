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

        ScoreManager.OnChange += UpdateBarImage;
    }

    private void OnDisable()
    {
        ScoreManager.OnChange -= UpdateBarImage;
    }

    private void UpdateBarImage(float amount)
    {
        var percentage = amount / ScoreManager.MaxScore;

        BarImage.color = Gradient.Evaluate(percentage);

        BarImage.fillAmount = percentage;
    }
}
