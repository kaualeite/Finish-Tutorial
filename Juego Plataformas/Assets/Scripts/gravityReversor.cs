﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityReversor : MonoBehaviour {

    private PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.antiGravity = true;
            player.playerRevertGravity();
           
        }


    }

 
}
