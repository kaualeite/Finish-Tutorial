using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistentManager : MonoBehaviour {
    public static persistentManager instance = null;
    public bool cargar = false;


	private void Awake()
	{
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
