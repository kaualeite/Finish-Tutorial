﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPower : MonoBehaviour {
    private Rigidbody2D rb2d;
    public PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "GroundColider")
        {


            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
