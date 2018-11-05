using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour {

	public int damageToTake = 1;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<EnemyHealth>().HurtEnemy(damageToTake);
		}
	}
}
