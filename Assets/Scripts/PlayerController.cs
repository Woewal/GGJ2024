using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float speed;
	[SerializeField]
	private bool canSprint = false;
	[SerializeField]
	private float normalSpeed = 4f;
	[SerializeField]
	private float sprintSpeed = 7.5f;
	[SerializeField]
	private bool canJump = false;
	[SerializeField]
	private float jumpForce = 8f;
	[SerializeField]
	private float gravity = 30f;
	private Vector3 moveDir = Vector3.zero;
	[SerializeField]
	private float maxDistanceHorizontal = 2f;
	[SerializeField]
	private float maxDistanceVertical = 2f;

	private void Start()
	{
		speed = normalSpeed;
	}

	void Update()
	{
		//Check if player is grounded
		CharacterController controller = gameObject.GetComponent<CharacterController>();
		if (controller.isGrounded)
		{
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			moveDir = transform.TransformDirection(moveDir);

			moveDir *= speed;

			//Jumps if the player presses the Jump button
			if (Input.GetButtonDown("Jump") && canJump)
			{
				moveDir.y = jumpForce;
			}
		}

        //Controls player speed
		if (Input.GetKey(KeyCode.LeftShift) && canSprint)
		{
			speed = sprintSpeed;
		}
		else
		{
			speed = normalSpeed;
		}

		//transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

		//Add gravity
		moveDir.y -= gravity * Time.deltaTime;

		controller.Move(moveDir * Time.deltaTime);

		//Setting the max distance for going left and right
		if(gameObject.transform.position.x <= -maxDistanceHorizontal)
        {
			gameObject.transform.position = new Vector3(-maxDistanceHorizontal, gameObject.transform.position.y, gameObject.transform.position.z);
        }
		if (gameObject.transform.position.x >= maxDistanceHorizontal)
		{
			gameObject.transform.position = new Vector3(maxDistanceHorizontal, gameObject.transform.position.y, gameObject.transform.position.z);
		}

		//Setting the max distance for going forward and backward
		if (gameObject.transform.position.z <= -maxDistanceVertical)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -maxDistanceVertical);
		}
		if (gameObject.transform.position.z >= maxDistanceVertical)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, maxDistanceVertical);
		}
	}
}
