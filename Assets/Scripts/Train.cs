using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;

    public GameObject TrainSmoke;

    public Transform TrainSmokeTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
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
