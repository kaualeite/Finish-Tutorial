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
        persistentManager.instance.life = int.Parse(fields[3]);h
        persistentManager.instance.maaxlife = int.Parse(fields[4]);
        persistentManager.instance.shield = int.Parse(fields[5]);
        persistentManager.instance.maxshield = int.Parse(fields[6]);
        persistentManager.instance.keys = float.Parse(fields[7]);
        persistentManager.instance.coins = float.Parse(fields[8]);
    }
}

