using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_checker : MonoBehaviour {
    private PlayerController player;
    private bool inmap = false;
    void Start()
    {
        player = GetComponentInParent<PlayerController>();

    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			inmap = false;
			if (inmap == false) {
				player.health = 0;

			} else {
				inmap = true;
			}
		}
	}
       
}
