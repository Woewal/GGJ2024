using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    float arcHeight = 5;
    public GameObject TargetPrefab;
    public GameObject SplashEffectPrefab;
    public AudioClip SplashSound;

    public AnimationCurve SpeedCurve;

    public void SetDestination(Vector3 position)
    {
        var target = Instantiate(TargetPrefab);
        target.transform.position = position;
        // Create a path with an upward arc
        Vector3[] path = new Vector3[] {
            transform.position, // Starting position
            (transform.position + position) / 2 + Vector3.up * arcHeight, // Midpoint with upward arc
            position // Target position
        };


        transform.DOLocalPath(path, 2f, PathType.CatmullRom)
            .SetEase(SpeedCurve)
            .OnComplete(() =>
            {
                var splashEffect = Instantiate(SplashEffectPrefab);
                splashEffect.transform.position = transform.position;


                Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

                // Iterate through the colliders to find the PlayerController component
                foreach (Collider collider in colliders)
                {
                    var playerController = collider.GetComponent<PlayerHit>();

                    // If PlayerController component is found, do something with it
                    if (playerController != null)
                    {
                        Destroy(gameObject);

                        ScoreManager.Instance.Score += 2;
                        playerController.Hit(10);
                        // Do something with the playerController, such as accessing its methods or properties
                        break; // If you only want to find the first player within range
                    }
                }

                AudioSource.PlayClipAtPoint(SplashSound, transform.position);

                Destroy(gameObject);
                Destroy(target);
            });
    }
}
