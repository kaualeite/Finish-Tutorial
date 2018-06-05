using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainMenu_to_firstscene : MonoBehaviour {
    
    public GameObject menu;
    private string filename = "data.txt";
    public string escena = "";
    public bool cargar = false;

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
        persistentManager.instance.cargar = true;
        cargar = true;
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
     
    }
}

