using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    float arcHeight = 5;
    public void SetDestination(Vector3 position)
    {
        // Create a path with an upward arc
        Vector3[] path = new Vector3[] {
            transform.position, // Starting position
            (transform.position + position) / 2 + Vector3.up * arcHeight, // Midpoint with upward arc
            position // Target position
        };


        transform.DOLocalPath(path, 3f, PathType.CatmullRom)
            .SetEase(Ease.InQuad) // You can adjust the easing function as needed
            .OnComplete(OnMoveComplete);
    }

    void OnMoveComplete()
    {
        Debug.Log("Movement complete!");
        // You can add any additional logic you want to execute when the movement is complete
    }
}
