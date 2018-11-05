using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	private Vector3 offset;
	public float rotateSpeed;
	public Transform pivot;
	public float maxViewAngle;
	public float minViewAngle;

	public bool invertY;

	// Use this for initialization
	void Start () {
		offset = target.position - transform.position;

		pivot.transform.position = target.transform.position;
		pivot.transform.parent = null;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		pivot.transform.position = target.transform.position;

		//Get X position of the mouse and rotate around the target
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		pivot.Rotate(0, horizontal, 0);

		//Get Y position of mouse, rotate pivot
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

		//check if Y is inverted
		if (invertY == true)
		{
			pivot.Rotate(vertical, 0, 0);
		}
		else
		{
			pivot.Rotate(-vertical, 0, 0);
		}

		//Limit how high the camera can go
		if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
		{
			pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
		}

		if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
		{
			pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
		}

		float desiredYAngle = pivot.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
		transform.position = target.position - (rotation * offset);

		if (transform.position.y < target.position.y)
		{
			transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
		}

		transform.LookAt(target);
	}
}
