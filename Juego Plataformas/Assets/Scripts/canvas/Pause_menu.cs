using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		
	public void Resume(){
		
		paused = !paused;


	}
    public void mainMenu()
    {

        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);


    }

	public void Quit(){

        Application.Quit();

	}

}
