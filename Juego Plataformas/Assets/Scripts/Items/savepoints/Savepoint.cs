using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Savepoint : MonoBehaviour {
    private PlayerController player;
    // Use this for initialization
    void Start () {
        player = GetComponentInParent<PlayerController>();
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
			player.grounded = true;
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
        sr.Close();
    }
}
