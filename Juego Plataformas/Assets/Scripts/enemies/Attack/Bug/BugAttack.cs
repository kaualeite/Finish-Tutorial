using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAttack : MonoBehaviour {

    public Collider2D attackTrigger;

    private bool attacking = false;
    private Animator anim;
    // Cooldown
    private float attackTimer = 0;
    private float attackCd = 1.5f;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.tag == "Player")
        {
            attacking = true;
            Invoke("BugTrigger", 0.3f);
            attackTimer = attackCd;
        }
        /*if (attacking)
        {
                attacking = false;
                attackTrigger.enabled = false;
        }*/
        anim.SetBool("Attack", attacking);
        attacking = false;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
            attackTrigger.enabled = false;
            //attacking = false;
    }

    private void BugTrigger()
    {
        attackTrigger.enabled = true;
    }
}