using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public float Score = MaxScore;
    public const float MaxScore = 100;

    public float DecreaseSpeed = 1;

    public Action<float> OnChange;
    public Action OnEmpty;
    public bool isEmpty { get { return Score == 0; } }


    private void Update()
    {
        if(!isEmpty)
            Change(-Time.deltaTime * DecreaseSpeed);
    }

    public void Change(float amount)
    {
        var previous = Score;

        Score += amount;

        if(Score > MaxScore)
        {
            Score = MaxScore;
        }

        if(Score < 0)
        {
            Score = 0;
            OnEmpty?.Invoke();
        }

        if (previous != Score)
        {
            OnChange?.Invoke(Score);
        }
    }
}
