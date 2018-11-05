using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int coinValue;

	public GameObject pickupEffect;

	public bool isSpecialPickup;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<GameManager>().AddCoin(coinValue);
			FindObjectOfType<HealthManager>().HealPlayer(coinValue);

			if (isSpecialPickup)
			{
				FindObjectOfType<GameManager>().DecreaseSpecial(1);
			}

			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
