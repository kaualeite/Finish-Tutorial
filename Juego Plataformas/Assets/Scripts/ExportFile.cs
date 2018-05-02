using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class ExportFile : MonoBehaviour {

	private PlayerController player;



	public void Start()
	{
		var fileName = "Nanu.txt";
		player = GetComponentInParent<PlayerController>();
		if (File.Exists(fileName))
		{
			Debug.Log(fileName+" already exists.");
			return;
		}
		var sr = File.CreateText(fileName);

		sr.WriteLine (SceneManager.GetActiveScene());
		sr.WriteLine (player.Savepointx);
		sr.WriteLine (player.savepointy);
		sr.Close();
	}


}
