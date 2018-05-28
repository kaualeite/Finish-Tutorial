using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPower : MonoBehaviour {
    private Rigidbody2D rb2d;
    public PlayerController player;
    public float push = 1;
    
    // Use this for initialization
    void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		


	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "GroundColider")
        {
            
        
            player.PlayerIsPushedByGreenPower(new Vector2(rb2d.velocity.x,rb2d.velocity.y), push);
            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
