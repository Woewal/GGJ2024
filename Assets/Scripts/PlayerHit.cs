using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHit : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] List<AudioClip> hitSounds;
    [SerializeField] List<AudioClip> goodSounds;
    [SerializeField] AudioClip laughSound;
    [SerializeField] GameObject StarEffect;

    public void Hit(float amount = 5.5f)
    {
        var randomClip = hitSounds[Random.Range(0, hitSounds.Count)];
        ScoreManager.Instance.ChangeRating(amount);

        var starEffect = Instantiate(StarEffect);
        starEffect.transform.position = transform.position;

        Animator.transform.DOPunchScale(Vector3.one * .3f, 0.1f, 0, 0).OnComplete(() => Animator.transform.localScale = Vector3.one);

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

    public void Gain(float amount = 5.5f)
    {
        ScoreManager.Instance.ChangeRating(-amount);

        var starEffect = Instantiate(StarEffect);
        starEffect.transform.position = transform.position;

        GameObject audioObject = new GameObject("DynamicAudioSource");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = goodSounds[Random.Range(0, goodSounds.Count)];

        audioSource.pitch = Random.Range(0.9f, 1.2f);
        audioSource.transform.position = transform.position;
        audioSource.Play();
        Destroy(audioObject, audioSource.clip.length);
    }
}
