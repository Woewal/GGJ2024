using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public List<AudioClip> hitSound;
    public bool IsPositive;

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
        var animationLength = 2f;
        if(!IsPositive)
        {
            transform.DOMove(new Vector3(Random.Range(-5, 5), Random.Range(10, 30), Random.Range(10, 20)), animationLength);
            transform.DOScale(Vector3.zero, animationLength);
        }
        else
        {
            Destroy(gameObject);
        }
        AudioSource.PlayClipAtPoint(hitSound[Random.Range(0, hitSound.Count)], transform.position);
        var Player = collider.gameObject.GetComponent<PlayerHit>();
        if (Player)
        {
            if(!IsPositive)
            {
            Player.Hit();
            }
            else
            {
                Player.Gain();
                ScoreManager.Instance.Score += 10;
            }
            ScoreManager.Instance.Score++;
        }
    }
}
