using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    [SerializeField] AudioSource musicSource;

    private void Start()
    {
        if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}
