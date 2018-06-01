using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyAttack : MonoBehaviour {
    
    public int damage;

    
    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.name == "Player")
        {
            col.SendMessage("EnemyKnockBack", transform.position.x);
            col.SendMessage("Hit", damage);
        }
    }
}
