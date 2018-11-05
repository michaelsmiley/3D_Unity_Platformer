using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

	public string star1Name;
	public string star2Name;
	public string star3Name;

	public GameObject checkMarkStar1;
	public GameObject checkMarkStar2;
	public GameObject checkMarkStar3;
	
	// Update is called once per frame
	void Update () {

		int star1Collected = PlayerPrefs.GetInt(star1Name);
		int star2Collected = PlayerPrefs.GetInt(star2Name);
		int star3Collected = PlayerPrefs.GetInt(star3Name);

		//Star 1
		if (star1Collected >= 1)
		{
			checkMarkStar1.SetActive(true);
		}

		else 
		{
			checkMarkStar1.SetActive(false);
		}

		//Star 2
		if (star2Collected >= 1)
		{
			checkMarkStar2.SetActive(true);
		}

		else
		{
			checkMarkStar2.SetActive(false);
		}

		//Star 3
		if (star3Collected >= 1)
		{
			checkMarkStar3.SetActive(true);
		}

		else
		{
			checkMarkStar3.SetActive(false);
		}
		
	}
}
