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

    // Timer
    public float timer;
    private float timerbc;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        timerbc = timer;
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

            while(timer != 0)
            {
                timer -= 0.5f;
            }
            
            if (timer == 0)
            {
                //Debug.LogError("TIMER");
                attackTrigger.enabled = true;
            }
            
            attackTimer = attackCd;
        }
        if (attacking) {
                attacking = false;
                attackTrigger.enabled = false;
        }
        anim.SetBool("Attack", attacking);
        attacking = false;
        timer = timerbc;
    }
}