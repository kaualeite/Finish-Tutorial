using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightInvoker : MonoBehaviour {
    public GameObject invoke;
	// Use this for initialization
    public bool invoked = false;
	void Start () {
        invoke.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (invoked)
        {

            invoke.SetActive(true);
            Time.timeScale = 0;

        }

        if (!invoked)
        {

            invoke.SetActive(false);
            Time.timeScale = 1;

        }
	}
}
