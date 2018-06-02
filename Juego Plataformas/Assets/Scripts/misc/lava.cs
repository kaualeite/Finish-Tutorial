using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

    public int damage;
    private PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("EnemyKnockBack", transform.position.x);
            other.SendMessage("Hit", damage);

        }
    }
}
