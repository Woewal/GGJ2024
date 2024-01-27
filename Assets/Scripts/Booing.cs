using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booing : MonoBehaviour
{
    ScoreManager ScoreManager;
    [SerializeField] AudioSource BooSource;
    [SerializeField] AnimationCurve Curve;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = ScoreManager.Instance;

        ScoreManager.OnRatingChange += ChangeVolume;
    }

    void ChangeVolume (float amount) {
        BooSource.volume = Curve.Evaluate(amount / ScoreManager.MaxRating);
    }
}
