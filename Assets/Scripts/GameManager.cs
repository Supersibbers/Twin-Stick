using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;
	private float fixedDeltaTime;
	private bool isPaused = false;

	void Start () {
		fixedDeltaTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1")) {
			recording = false;
		} else {
			recording = true;
		}

		if (Input.GetKeyDown (KeyCode.P) && isPaused) {
			ResumeGame();
		} else if (Input.GetKeyDown (KeyCode.P) && !isPaused) {
			PauseGame();
		}
	}

	void PauseGame () {
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
		isPaused = true;
	}
	void ResumeGame () {
		Time.timeScale = 1;
		Time.fixedDeltaTime = fixedDeltaTime;
		isPaused = false;
	}

	void OnApplicationPause (bool pauseStatus) {
		isPaused = pauseStatus;
	}
}
