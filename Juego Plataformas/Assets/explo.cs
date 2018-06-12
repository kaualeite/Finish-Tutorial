﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explo : MonoBehaviour {
    public float pushing = 6;
	// Use this for initialization
    private bool attacking = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            attacking = true;
        }
       
        if (col.gameObject.tag == "Ground")
        {
            attacking = true;
        }
        anim.SetBool("Explo", attacking);
        // Para q vuelva a es
        Invoke("Attack", 0.5f);
    }

    private void Attack()
    {
        attacking = false;
        anim.SetBool("Explo", attacking);
        Invoke("Borrar", 0.1f);
    }

    private void Borrar()
    {
        Destroy(GameObject.Find(this.gameObject.name));
    }
    public void PlayerPushBomb(Vector2 vector, float push)
    {
        vector.Normalize();
        rb2d.AddForce(new Vector2(vector.x * push, vector.y * push));

    }
}

