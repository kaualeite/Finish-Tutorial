using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriger : MonoBehaviour {

    private int dmg;
    private int health;

    void Start()
    {
        dmg = 10;
        health = 20;
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.LogError(col.name);
        if (/*col.isTrigger != true && */col.CompareTag("Blue_Enemy")) {
            Destroy(col.gameObject);
        }else if (col.CompareTag("Bicho"))
        {
            health = health - dmg;
            if(health == 0)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
