using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_spike : MonoBehaviour {
    public PlayerController player;
    // Use this for initialization
    void Start () {
        player = GetComponentInParent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        
        if (col.gameObject.tag == "spike")
        {


            player.Hit(50);


        }
        }
    }
