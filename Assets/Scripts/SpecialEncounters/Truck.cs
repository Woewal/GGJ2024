using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;
    [SerializeField]
    private float horizontalSpeed = 0f;
    private float horizontalSpeedChange = -0.03f;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float newZ = 1 * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z - newZ);
        if (horizontalSpeed >= 5f) horizontalSpeedChange = -0.03f;
        if (horizontalSpeed <= -5f) horizontalSpeedChange = 0.03f;
        horizontalSpeed += horizontalSpeedChange;

        //transform.position -= new Vector3(transform.position.x, transform.position.y, 1) * speed * Time.deltaTime;
        if (transform.position.z <= 60) speed -= 0.2f;
        if(speed <= 0) speed = 0;
    }
}
