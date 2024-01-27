using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public const float MaxRating = 100;
    private float _rating = MaxRating / 2;
    public float Rating
    {
        get { return _rating; }
        set
        {
             var previous = _rating;

            // Set the value
            _rating = value;


            if(_rating <= 0)
            {
                _rating = 0;
                OnRatingEmpty?.Invoke();
            }

            if(_rating > MaxRating)
            {
                _rating = MaxRating;
            }

            if(previous != _rating) { OnRatingChange?.Invoke(value); }

            
        }
    }

    float currentTime = 0;

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            // Set the value
            _score = value;

            OnScoreChange?.Invoke(value);
        }
    }

    public AnimationCurve DecreaseSpeed;

    public Action<float> OnRatingChange;
    public Action<int> OnScoreChange;
    public Action OnRatingEmpty;
    public bool IsEmpty { get { return Rating == 0; } }

    public Transform Highscore;

    private void Start()
    {
        OnRatingEmpty += () => Highscore.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(!IsEmpty) ChangeRating(-Time.deltaTime * DecreaseSpeed.Evaluate(currentTime));

        currentTime += Time.deltaTime;
    }

    public void ChangeRating(float amount)
    {
        Rating += amount;
    }
}
