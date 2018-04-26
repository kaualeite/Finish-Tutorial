using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private PlayerController player;
    private Rigidbody2D rb2d;
	public Sprite sprite;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}
	
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Plataform") {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") {
            player.grounded = true;
        }

        if (col.gameObject.tag == "Platform") {
            player.transform.parent = col.transform;
            player.grounded = true;
        }

		if (col.gameObject.tag == "Key") {
			player.keyNumber = player.keyNumber + 1;

			player.grounded = true;
		}
    }

	void OnTriggerEnter2D ( Collider2D otro) {
		if (otro.gameObject.tag == "Save") {
			var positions = GameObject.Find(otro.collider.gameObject.name).transform.position;
			player.Savepointx = positions.x;
			player.savepointy = positions.y;

			player.grounded = true;
		}
	}

    void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			player.grounded = false;
		}

        if (col.gameObject.tag == "Platform"){
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
