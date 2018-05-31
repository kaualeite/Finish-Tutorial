using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightPower : MonoBehaviour {

    Rigidbody2D rb2d;
    public GameObject player;
    public PlayerController play;
    public float timeToDestroy;
    private float firstTime;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player"));
        play = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.AddComponent<Confusion>();
            play.confused = true;
            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
