using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthExtenser : MonoBehaviour {

    public PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.maxhealth = player.maxhealth + 20;
            player.health = player.maxhealth;
            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
