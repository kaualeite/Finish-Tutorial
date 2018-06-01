using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAttack : MonoBehaviour {

    public Collider2D attackTrigger;
    public int damage;

    void Awake()
    {
        attackTrigger.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.name == "Player")
        {
            attackTrigger.enabled = true;
            col.SendMessage("EnemyKnockBack", transform.position.x);
            col.SendMessage("Hit", damage);
        }
    }
}
