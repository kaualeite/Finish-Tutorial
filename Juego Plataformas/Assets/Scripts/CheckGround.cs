using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private PlayerController player;
    private Rigidbody2D rb2d;
	public Sprite sprite;
    private GameObject key;
	private Key okey;
	private bool inmap;
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



    void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			player.grounded = false;
		}

        if (col.gameObject.tag == "Platform"){
            player.transform.parent = null;
            player.grounded = false;
        }
       

    }


        void OnTriggerEnter2D(Collider2D other)
        {

        if (other.gameObject.tag == "Key")
        {

            player.keyNumber = player.keyNumber + 1;
            Destroy(GameObject.Find(other.gameObject.name));
            player.grounded = true;
        }
        if (other.gameObject.tag == "KeyDoor")
        {
            if (player.keyNumber > 0)
            {
				

                //problems
             //   var posobject = doorkey.x;
				player.transform.position = new Vector3(okey.positionx,okey.positiony, 0);
                player.keyNumber = player.keyNumber - 1;
                player.grounded = true;
            }
            else{

                

            }
        }
        if (other.gameObject.tag == "Save")
        {
            var positions = GameObject.Find(other.gameObject.name).transform.position;
            player.Savepointx = positions.x;
            player.savepointy = positions.y;

            player.grounded = true;
        }

		if (other.gameObject.tag == "Checker") {
			inmap = false;
			if (!inmap) {
				player.health = 0;
			
			}


		} else {
			
			inmap = true;
		}

    }
    
}
