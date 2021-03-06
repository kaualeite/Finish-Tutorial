﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour {
    public PlayerController player;
    public float timeToDestroy = 2;
    private float firstTime = 2;
	// Use this for initialization
	void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        player.maxSpeed = player.maxSpeed - 2;
        player.changeStatus = true;
        player.slowed = true;
	}
	
	// Update is called once per frame
	void Update () {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {

            player.maxSpeed = player.maxSpeed + 2;
            player.changeStatus = false;
            player.slowed = false;
            timeToDestroy = firstTime;
            Destroy(this);

        }
	}
}
