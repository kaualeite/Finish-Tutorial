using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_checker : MonoBehaviour {
    private PlayerController player;
    private bool inmap = false;
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);


    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Checker") {
			inmap = false;
			if (inmap == false) {
				player.health = 0;
                player.shield = 0;

			} else {
				inmap = true;
			}
		}
	}
       
}
