﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip : MonoBehaviour {

    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(0, 900));
    }
	
	// Update is called once per frame
	void Update () {
   
    }
}