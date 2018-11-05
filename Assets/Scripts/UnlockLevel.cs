using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour {

	public GameObject levelBlocker;
	private int currentStars;
	public int starsNeeded;

	// Use this for initialization
	void Start () {
		currentStars = PlayerPrefs.GetInt("PlayerStars");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentStars >= starsNeeded)
		{
			levelBlocker.SetActive(false);
		}
	}
}
