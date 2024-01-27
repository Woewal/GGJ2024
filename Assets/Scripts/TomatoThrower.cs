using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoThrower : MonoBehaviour
{
    public Tomato TomatoPrefab;
    public List<Transform> ThrowTransforms;
    public CharacterController CharacterController;
    public float HorizontalMovement;
    public float VerticalMovement;

    private void Start()
    {
        StartCoroutine(ThrowCoroutine());
    }

    IEnumerator ThrowCoroutine ()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            var tomato = Instantiate(TomatoPrefab);
            tomato.transform.position = ThrowTransforms[Random.Range(0, ThrowTransforms.Count)].position + Vector3.up * 1.8f;

            tomato.SetDestination(new Vector3(Random.Range(-HorizontalMovement, HorizontalMovement), 0, Random.Range(-VerticalMovement, VerticalMovement)));
        }


    }
}
