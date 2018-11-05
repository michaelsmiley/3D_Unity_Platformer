using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPickup : MonoBehaviour {

	public GameObject pickupEffect;

	public GameObject starObject;

	public string starName;

	// Update is called once per frame
	void Update () {
		int starCollected = PlayerPrefs.GetInt(starName);

		if (starCollected == 0)
		{
			starObject.SetActive(true);
		}

		else
		{
			starObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<GameManager>().AddStar(1);
			Instantiate(pickupEffect, transform.position, transform.rotation);

			PlayerPrefs.SetInt(starName, 1);
			starObject.SetActive(false);
		}
	}
}
