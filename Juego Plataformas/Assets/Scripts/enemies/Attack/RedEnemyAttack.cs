using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyAttack : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {

        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.tag == "Player")
        {

            float yOffSet = 0.14f;
            if (transform.position.y + yOffSet < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }
    }
}
