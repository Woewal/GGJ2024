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
        AudioSource.PlayClipAtPoint(hitSound[Random.Range(0, hitSound.Count)], transform.position);
        transform.DOPunchScale(Vector3.one * .3f, 0.1f, 0, 0);
        var Player = collider.gameObject.GetComponent<PlayerHit>();
        if (Player) {
            Player.Hit();
            ScoreManager.Instance.Score++;
        } 
    }
}
