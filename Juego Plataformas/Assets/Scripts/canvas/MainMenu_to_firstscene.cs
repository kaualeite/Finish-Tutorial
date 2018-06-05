using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainMenu_to_firstscene : MonoBehaviour {

    public GameObject menu;
    private string filename = "data.txt";
    public string escena = "";
    public float posx = 0;
    public float posy = 0;

	// Use this for initialization
	void Start () {
        menu.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void continueGame()
    {

        read();
        SceneManager.LoadScene(escena, LoadSceneMode.Single);
    }
	public void newGame(){

        SceneManager.LoadScene("first", LoadSceneMode.Single);
	}

	public void Quit(){

		Application.Quit();

	}
 

    public void read()
    {
        StreamReader reader = new StreamReader("./Save.txt");
        string itemStrings = reader.ReadLine();
        char[] delimiter = {';' };
        string[] fields = itemStrings.Split(delimiter);
        while (itemStrings != null)
        {
           

            for (int i = 0; i < fields.Length; i++)
            {
             
                Debug.Log(fields[i]);


            }

            itemStrings = reader.ReadLine();
         

        }
        escena = fields[0];
        posx = float.Parse(fields[1]);
        posy = float.Parse(fields[2]);
    }
}

