using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject mainCamera;
	public GameObject pauseCamera;
	public bool isPaused;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (isPaused)
			{
				isPaused = false;
				pauseMenu.SetActive(false);
				mainCamera.SetActive(true);
				pauseCamera.SetActive(false);
				Time.timeScale = 1f;
			}

			else
			{
				isPaused = true;
				pauseMenu.SetActive(true);
				pauseCamera.SetActive(true);
				mainCamera.SetActive(false);
				Time.timeScale = 0f;
			}
		}

		if (isPaused && Input.GetKeyDown(KeyCode.E))
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene("MainMenu");
		}
	}
}
