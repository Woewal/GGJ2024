using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSmokeUpwards : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, -0.25f, -10) * speed * Time.deltaTime;
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
