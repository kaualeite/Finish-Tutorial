using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
    private PlayerController player;
    private Rigidbody2D rb2;
    private GameObject p;
	// Use this for initialization
	void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        p = (GameObject.Find("Player"));
        

    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.gravity = new Vector3(0, 9, 0);


            player.grounded = false;
            player.doubleJump = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.gravity = new Vector3(0, 9, 0);
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
