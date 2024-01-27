using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribuneCharacter : MonoBehaviour
{
    [SerializeField] Animator CharacterAnimator;

    [SerializeField] List<string> animations = new List<string>();
    // Start is called before the first frame update

    private void Start()
    {
        CharacterAnimator.SetBool(animations[Random.Range(0, animations.Count)], true);
    }
}
