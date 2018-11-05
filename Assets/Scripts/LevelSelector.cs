using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public string toLevel;

	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene(toLevel);
	}
}
