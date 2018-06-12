using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private bool attacking = false;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.tag == "Player")
        {
            attacking = true;
            anim.SetBool("Explode", attacking);
        }
        

    }
}
