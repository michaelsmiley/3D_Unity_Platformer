using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject thePlatform;
	public GameObject thePlayer;

	void OnTriggerEnter()
	{
		thePlayer.transform.parent = thePlatform.transform;
	}

	void OnTriggerExit()
	{
		thePlayer.transform.parent = null;
	}
}
