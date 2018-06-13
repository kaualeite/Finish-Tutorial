using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikuController : MonoBehaviour {
    public int mikuHealth;
    public int mikuMaxhealth = 5000;
    public bool atackt2 = false;
	// Use this for initialization
	void Start () {
        mikuHealth = mikuMaxhealth;
	}
	
	// Update is called once per frame
	void Update () {


        if(mikuHealth == mikuMaxhealth/2){
            atackt2 = true;
        }
	}
}
