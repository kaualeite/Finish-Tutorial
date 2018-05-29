using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyAttack : MonoBehaviour {
    /*
    public PlayerController player;
    public int damage;

    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.name == "Player")
        {
            //player.EnemyKnockBack(player.transform.position.x, damage);
            col.SendMessage("EnemyKnockBack", transform.position.x);
        }
    }
}
