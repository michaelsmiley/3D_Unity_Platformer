using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

	public Transform thePlayer;

	public float distanceFromPlayer;

	public float chasingDistance;

	public float chaseSpeed;

	public float visionCone;

	public bool isRandomPatrol;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWaypoint = 0;
	public float rotateSpeed;
	public float wanderSpeed;

	public float accuracyToWaypoint;
	
	// Update is called once per frame
	void Update () {
		
		Vector3 direction = thePlayer.position - this.transform.position;
		direction.y = 0;
		float visionAngle = Vector3.Angle(direction, this.transform.position);

		if (state == "patrol" && waypoints.Length > 0)
		{
			if (isRandomPatrol == false)
			{
				if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < accuracyToWaypoint)
				{
					currentWaypoint++;

					if (currentWaypoint >= waypoints.Length)
					{
						currentWaypoint = 0;
					}
				}
			}

			if (isRandomPatrol == true)
			{
				if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < accuracyToWaypoint)
				{
					currentWaypoint = Random.Range(0, waypoints.Length);
				}
			}

			direction = waypoints[currentWaypoint].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
			this.transform.Translate(0,0, Time.deltaTime * wanderSpeed);
		}

		if (Vector3.Distance(thePlayer.position, this.transform.position) < distanceFromPlayer && (visionAngle < visionCone || state == "persuing"))
		{
			state = "persuing";

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);

			if (direction.magnitude > chasingDistance)
			{
				this.transform.Translate(0, 0, chaseSpeed * Time.deltaTime);
			}
		}

		else
		{
			state = "patrol";
		}

	}
}
