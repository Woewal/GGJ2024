using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Destinations : MonoBehaviour
{
    float arcHeight = 5;
    public GameObject TargetPrefab;

    public AnimationCurve SpeedCurve;

    private bool grounded = false;
    [SerializeField]
    private float speed = 10;

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
                //var splashEffect = Instantiate(SplashEffectPrefab);
                //splashEffect.transform.position = transform.position;


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
                //Destroy(gameObject);
                Destroy(target);
                grounded = true;
                StartCoroutine(DestroyAfterSeconds());
            });
    }

    private void Update()
    {
        if (!grounded) return;
        transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(5);
    }
}
