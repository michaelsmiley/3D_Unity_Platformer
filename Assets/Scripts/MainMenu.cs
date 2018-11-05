using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public int currentStars;
	public int isCollected;

	public void StartGame()
	{
		SceneManager.LoadScene("LevelHub");
		PlayerPrefs.SetInt("PlayerStars", 0);
		Reset();
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene("LevelHub");
		PlayerPrefs.GetInt("PlayerStars", currentStars);
		StarTracker();
	}

	public void ControlScreen()
	{
		SceneManager.LoadScene("ControlScreen");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void StarTracker()
	{
		PlayerPrefs.GetInt("L1S1", isCollected);
		PlayerPrefs.GetInt("L1S2", isCollected);
		PlayerPrefs.GetInt("L1S3", isCollected);
	}

	public void Reset()
	{
		PlayerPrefs.SetInt("L1S1", 0);
		PlayerPrefs.SetInt("L1S2", 0);
		PlayerPrefs.SetInt("L1S3", 0);
	}
}
