using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.grounded = false;
            player.doubleJump = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.grounded = false;
            player.doubleJump = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.grounded = false;
            player.doubleJump = false;
            player.jump = false;
        }
    }

}
