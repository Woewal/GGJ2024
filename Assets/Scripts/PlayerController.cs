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
	private float jumpForce = 8f;
	[SerializeField]
	private float gravity = 30f;
	private Vector3 moveDir = Vector3.zero;

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
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

			moveDir = transform.TransformDirection(moveDir);

			moveDir *= speed;

			//Jumps if the player presses the Jump button
			if (Input.GetButtonDown("Jump"))
			{
				moveDir.y = jumpForce;
			}
		}

        //Controls player speed
        if (canSprint)
        {
			if (Input.GetKey(KeyCode.LeftShift))
			{
				speed = sprintSpeed;
			}
			else
			{
				speed = normalSpeed;
			}
		}

		transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

		//Add gravity
		moveDir.y -= gravity * Time.deltaTime;

		controller.Move(moveDir * Time.deltaTime);
	}
}
