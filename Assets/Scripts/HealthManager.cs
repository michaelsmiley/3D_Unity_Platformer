using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public Image healthBar;

	public float invincibilityLength;
	private float invincibilityCounter;

	public Renderer playerRenderer;

	public float flashCounter;
	public float flashLength = 0.1f;

	private bool isRespawning;
	private Vector3 respawnPoint;
	public float respawnTime;

	public PlayerController thePlayer;

	public GameObject deathEffect;

	//Fader
	public Image fader;
	public float fadeSpeed;
	public float waitForFade;
	public bool isFadeTo;

	

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

		respawnPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Set the player invincibility after being hit
		if (invincibilityCounter > 0)
		{
			invincibilityCounter -= Time.deltaTime;

			//make player flash while invincibility is on
			flashCounter -= Time.deltaTime;

			if (flashCounter <= 0)
			{
				playerRenderer.enabled = !playerRenderer.enabled;
				flashCounter = flashLength;
			}

			//make sure player is still visible
			if (invincibilityCounter <= 0)
			{
				playerRenderer.enabled = true;
			}
		}

		if (isFadeTo)
		{
			fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, Mathf.MoveTowards(fader.color.a, 1f, fadeSpeed * Time.deltaTime));
			if (fader.color.a == 1)
			{
				isFadeTo = false;
			}
		}
	}

	public void HurtPlayer(float damage, Vector3 direction)
	{
		if (invincibilityCounter <= 0)
		{
			currentHealth -= damage;
			UpdateHealthBar();

			if (currentHealth <= 0)
			{
				Respawn();
			}
			else
			{
				thePlayer.KnockBack(direction);
				invincibilityCounter = invincibilityLength;

				//Make player flash when hit
				playerRenderer.enabled = false;
				flashCounter = flashLength;
			}
		}
	}

	public void Respawn()
	{
		if (!isRespawning)
		{
			StartCoroutine("RespawnPlayer");
		}
	}

	IEnumerator RespawnPlayer()
	{
		isRespawning = true;
		thePlayer.gameObject.SetActive(false);
		Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);
		yield return new WaitForSeconds(respawnTime);

		isFadeTo = true;
		yield return new WaitForSeconds(waitForFade);
		isFadeTo = false; 

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		isRespawning = false;

		thePlayer.gameObject.SetActive(true);
		thePlayer.transform.position = respawnPoint;
		currentHealth = maxHealth;
	}

	void UpdateHealthBar()
	{
		healthBar.fillAmount = currentHealth/maxHealth;
	}

	public void HealPlayer(int healAmount)
	{
		currentHealth += healAmount;
		UpdateHealthBar();

		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
}
