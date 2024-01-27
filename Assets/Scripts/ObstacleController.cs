using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public List<AudioClip> hitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        var animationLength = 5f;
        transform.DOMove(new Vector3(Random.Range(-5, 5),Random.Range(10, 30), Random.Range(10, 20)), animationLength);
        transform.DOScale(Vector3.zero, animationLength); 
    }
}
