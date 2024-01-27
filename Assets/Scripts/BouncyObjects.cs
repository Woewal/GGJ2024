using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyObjects : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool goUp = true;
    [SerializeField]
    private float maxBounce;

    private Vector3 originPosition;

    private void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        switch (goUp)
        {
            case true:
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
                break;
            case false:
                transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
                break;
        }
        if(transform.position.y <= (originPosition.y - maxBounce)) goUp = true;
        if(transform.position.y >= (originPosition.y + maxBounce)) goUp = false;
    }
}
