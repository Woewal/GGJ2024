using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField]
    private float speed = 60;
    [SerializeField]
    private float horizontalSpeed = 5f;
    private float horizontalSpeedChange = -0.03f;

    public List<Destinations> ThrowObjects;
    public Destinations destination;
    public List<Transform> ThrowTransforms;
    //public CharacterController CharacterController;
    public float HorizontalMovement;
    public float VerticalMovement;
    [SerializeField]
    private int amountOfObjects = 10;
    [SerializeField]
    private int extraObjectEachTruck = 5;
    private int thrownObjects = 0;
    private bool isThrowing = false;
    private bool drivingForward = false;
    private bool canThrown = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Changing the position
        float newZ = 1 * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z - newZ);
        
        //Going left/right position
        if (horizontalSpeed >= 5f) horizontalSpeedChange = -0.03f;
        if (horizontalSpeed <= -5f) horizontalSpeedChange = 0.03f;
        horizontalSpeed += horizontalSpeedChange;

        if (drivingForward)
        {
            if (speed > -60) speed -= 0.2f;
            if (speed <= -60) speed = -60;
            if(transform.position.z >= 200) canThrown = false;
            if(transform.position.z >= 700) gameObject.SetActive(false);
            return;
        }

        //Forward speed position
        if (transform.position.z <= 60) speed -= 0.2f;
        if (speed <= 0)
        {
            speed = 0;
            if (isThrowing) return;
            isThrowing = true;
            StartCoroutine(ThrowCoroutine());
        }
    }

    IEnumerator ThrowCoroutine()
    {
        while (canThrown == true)
        {
            int randomNumber = Random.Range(0, ThrowObjects.Count);
            destination = ThrowObjects[randomNumber];
            Debug.Log(ThrowObjects[randomNumber]);
            yield return new WaitForSeconds(0.2f);
            var throwObject = Instantiate(destination);
            throwObject.transform.position = ThrowTransforms[Random.Range(0, ThrowTransforms.Count)].position + Vector3.up * 1.8f;

            throwObject.SetDestination(new Vector3(Random.Range(-HorizontalMovement, HorizontalMovement), 0, transform.position.z - 15 + Random.Range(-VerticalMovement, VerticalMovement)));
            thrownObjects++;
            if(thrownObjects >= amountOfObjects && !drivingForward)
            {
                drivingForward = true;
                amountOfObjects += extraObjectEachTruck;
            }  
        }
    }

    private void OnEnable()
    {
        drivingForward = false;
        isThrowing = false;
        canThrown = true;
        gameObject.transform.position = new Vector3(0, 0, 660);
        speed = 60;
        horizontalSpeed = 5;
        horizontalSpeedChange = -0.03f;
        thrownObjects = 0;
    }
}
