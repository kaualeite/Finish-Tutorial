using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_controller : MonoBehaviour
{
    private PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Key") {

			player.keyNumber = player.keyNumber + 1;
			Destroy (GameObject.Find (other.gameObject.name));
			player.grounded = true;
		}
	}
    
}