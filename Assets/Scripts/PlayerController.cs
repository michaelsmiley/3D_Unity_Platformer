using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	public float jumpForce;

	public float gravityScale;

	public CharacterController controller;

	private Vector3 moveDirection;

	public Transform pivot;

	public float rotateSpeed;

	public GameObject playerModel;

	public Animator playerAnimator;

	//Knockback variables
	public float knockBackForce;
	public float knockBackTime;
	private float knockBackCounter;

	public bool isDeathCatch;
	public int deathCatchAmount;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isDeathCatch == true)
		{
			if (transform.position.y < deathCatchAmount)
			{
				Vector3 hitDirection = transform.position;
				
				float damageToPlayer = FindObjectOfType<HealthManager>().maxHealth;

				FindObjectOfType<HealthManager>().HurtPlayer(damageToPlayer, hitDirection);
			}
		}

		//check if knocked back when hit
		if (knockBackCounter <= 0)
		{

			float yStore = moveDirection.y;

			moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

			moveDirection = moveDirection.normalized * moveSpeed;

			moveDirection.y = yStore;

			if(controller.isGrounded)
			{
				moveDirection.y = 0f;

				if (Input.GetButtonDown("Jump"))
				{
					moveDirection.y = jumpForce;
				}
			}
		}
		else
		{
			knockBackCounter -= Time.deltaTime;
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
		
		controller.Move(moveDirection * Time.deltaTime);

		//Move the player based on the camera direction
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);

			//Gradually rotate Player
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

			//Apply the newRotation to the Player
			playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
		}

		//Set up our Animation Parameters
		playerAnimator.SetBool("isGrounded", controller.isGrounded);
		playerAnimator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
		playerAnimator.SetFloat("aboveGround", moveDirection.y);
	}

	public void KnockBack(Vector3 direction)
	{
		knockBackCounter = knockBackTime;
		moveDirection = direction * knockBackForce;
		moveDirection.y = knockBackForce;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "JumpZone")
		{
			moveDirection.y = jumpForce;
		}
	}
}
