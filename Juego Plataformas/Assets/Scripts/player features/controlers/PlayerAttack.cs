using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 1.5f;
    public PlayerController player;
    public Collider2D attackTrigger;

    private Animator anim;

    void Awake() {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (!player.lightned)
        {
            if (Input.GetKeyDown("z") && !attacking)
            {
                attacking = true;
                attackTimer = attackCd;

                attackTrigger.enabled = true;
            }

            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    //Debug.LogError("timer");
                    attacking = false;
                    attackTrigger.enabled = false;
                }
            }

            anim.SetBool("Attacking", attacking);
        }
    }
}