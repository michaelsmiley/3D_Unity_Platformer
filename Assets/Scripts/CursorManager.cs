using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

	public bool cursorLocked;
	
	// Update is called once per frame
	void Start () {
		
		if (cursorLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		else if (!cursorLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

	}
}
