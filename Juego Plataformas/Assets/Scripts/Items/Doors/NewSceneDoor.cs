using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NewSceneDoor : MonoBehaviour {
    public string scenetogo;
    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            persistentManager.instance.cargarHud = true;
            Extract();
            SceneManager.LoadScene(scenetogo, LoadSceneMode.Single);

        }
    }
    public void Extract()
    {
        var fileName = "Save.txt";
       
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        var sr = File.CreateText(fileName);

        sr.Write(SceneManager.GetActiveScene().name + ";");
        sr.Write(player.Savepointx + ";");
        sr.Write(player.savepointy + ";");
        sr.Write(player.health + ";");
        sr.Write(player.maxhealth + ";");
        sr.Write(player.shield + ";");
        sr.Write(player.maxshield + ";");
        sr.Write(player.coins + ";");
        sr.Write(player.keyNumber + ";");
        sr.Close();
    }
}
