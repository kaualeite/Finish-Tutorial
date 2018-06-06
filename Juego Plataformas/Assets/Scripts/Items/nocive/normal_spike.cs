using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_spike : MonoBehaviour {
    public PlayerController player;
    public int damage;
    // Use this for initialization
    void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.EnemyKnockBack(15);
            player.Hit(damage);
        }
    }
}
