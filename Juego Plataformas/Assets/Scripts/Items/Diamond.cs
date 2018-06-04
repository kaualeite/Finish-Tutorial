using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    private PlayerController player;

    // Use this for initialization
    void Start () {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.coins = player.coins + 1;
            Destroy(GameObject.Find(this.gameObject.name));
        }
    }
}
