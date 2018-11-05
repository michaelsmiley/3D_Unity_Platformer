using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int currentCoin;
	public int currentStars;

	public Text coinText;
	public Text starText;

	public GameObject coinStar;
	public GameObject pickupStar;
	public int specialPickupLeft;

	// Use this for initialization
	void Start () {
		currentStars = PlayerPrefs.GetInt("PlayerStars");
		starText.text = "" + currentStars;
	}
	
	public void AddCoin(int coinToAdd)
	{
		currentCoin += coinToAdd;
		coinText.text = "" + currentCoin;

		if (currentCoin == 100)
		{
			coinStar.SetActive(true);
		}
	}

	public void AddStar(int starToAdd)
	{
		currentStars += starToAdd;
		starText.text = "" + currentStars;
		PlayerPrefs.SetInt("PlayerStars", currentStars); 
	}

	public void DecreaseSpecial(int specialPickup)
	{
		specialPickupLeft -= specialPickup;

		if (specialPickupLeft == 0)
		{
			pickupStar.SetActive(true);
		}
	}
}
