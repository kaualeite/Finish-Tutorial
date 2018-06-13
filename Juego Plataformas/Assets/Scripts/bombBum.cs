using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBum : MonoBehaviour {
    public int damage = 70;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // Comprobación de que es el jugador quien interactua con el
        if (col.gameObject.name == "Player")
        {
            
            col.SendMessage("EnemyKnockBack", 50);
            col.SendMessage("Hit", damage);
        }
    }
}
