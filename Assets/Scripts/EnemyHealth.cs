using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 1;

	public GameObject deathEffect;
	
	// Update is called once per frame
	void Update () {
		
		if (health <= 0)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	public void HurtEnemy(int damage)
	{
		health -= damage;
	}
}
