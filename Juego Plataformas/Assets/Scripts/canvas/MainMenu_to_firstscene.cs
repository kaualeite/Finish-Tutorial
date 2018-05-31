using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_to_firstscene : MonoBehaviour {

    public GameObject menu;
	// Use this for initialization
	void Start () {
        menu.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void continueGame()
    {

        SceneManager.LoadScene("nuevaScene", LoadSceneMode.Single);
    }
	public void newGame(){

        SceneManager.LoadScene("nuevaScene", LoadSceneMode.Single);
	}

	public void Quit(){

		Application.Quit();

	}
}
