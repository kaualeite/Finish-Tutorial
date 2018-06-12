using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explo : MonoBehaviour {

	// Use this for initialization
    private bool attacking = false;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.tag == "Player")
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
    }

    private void Borrar()
    {
        Destroy(this);
    }
}

