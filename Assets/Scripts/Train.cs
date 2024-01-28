using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;

    public GameObject TrainSmoke;

    public Transform TrainSmokeTransform;

    public AudioSource TrainSound;

    bool playingSound = false;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        if (transform.position.z <= 300) PlaySound();
        if(transform.position.z <= -500)
        {
            DisableTrain();
        }
    }

    void DisableTrain()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(10.2f, 3.8f, 660);
        StartCoroutine(SpawnSmoke());
        playingSound = false;
    }

    void PlaySound()
    {
        if (playingSound) return;
        playingSound = true;
        TrainSound.Play();
    }

    IEnumerator SpawnSmoke()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(TrainSmoke, TrainSmokeTransform);
        }
    }
}
