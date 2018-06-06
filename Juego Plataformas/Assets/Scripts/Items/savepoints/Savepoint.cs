using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class Savepoint : MonoBehaviour {
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
		if (other.gameObject.tag == "Save") {
			var positions = GameObject.Find (other.gameObject.name).transform.position;
			player.Savepointx = positions.x;
			player.savepointy = positions.y;
			Extract ();
           

		}
        

    }

public void Extract()
    {
        var fileName = "Save.txt";
        player = GetComponentInParent<PlayerController>();
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
