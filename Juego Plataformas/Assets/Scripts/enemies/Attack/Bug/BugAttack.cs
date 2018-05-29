using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAttack : MonoBehaviour {

    public Collider2D attackTrigger;
    private bool attacking = false;
    private Animator anim;

    private float attackTimer = 0;
    private float attackCd = 1.5f;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        //anim.SetBool("Attacking", );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.tag == "Player")
        {
            attacking = true;
            attackTrigger.enabled = true;
            attackTimer = attackCd;
        }
        if (attacking) {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Attack", attacking);
        attacking = false;
    }
}