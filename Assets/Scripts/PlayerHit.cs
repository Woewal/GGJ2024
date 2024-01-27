using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHit : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] List<AudioClip> hitSounds;
    [SerializeField] AudioClip laughSound;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Hit();
        }
    }

    public void Hit()
    {
        var randomClip = hitSounds[Random.Range(0, hitSounds.Count)];
        ScoreManager.Instance.ChangeRating(5.5f);

        Animator.transform.DOPunchScale(Vector3.one * .3f, 0.1f, 0, 0);

        GameObject audioObject = new GameObject("DynamicAudioSource");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = randomClip;

        audioSource.pitch = Random.Range(0.9f, 1.2f);
        audioSource.transform.position = transform.position;
        audioSource.Play();
        Destroy(audioObject, audioSource.clip.length);

        GameObject laughObject = new GameObject("DynamicAudioSource");
        AudioSource laughSource = laughObject.AddComponent<AudioSource>();
        laughSource.volume = .4f;
        laughSource.clip = laughSound;

        laughSource.pitch = Random.Range(0.9f, 1.2f);
        laughSource.transform.position = transform.position;
        laughSource.Play();
        Destroy(laughObject, laughSource.clip.length);

        this.Animator.SetTrigger("stumble");

    }
}
