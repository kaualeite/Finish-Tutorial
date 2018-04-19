using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour {

	public GameObject pause;

	private bool paused = false;

	void Start(){

		pause.SetActive (false);
	}

	void Update(){

		if (Input.GetButtonDown ("Paused")) {

			paused = !paused;

		}

		if (paused) {

			pause.SetActive (true);
			Time.timeScale = 0;

		}

		if (!paused) {

			pause.SetActive (false);
			Time.timeScale = 1;

		}

	}
}
