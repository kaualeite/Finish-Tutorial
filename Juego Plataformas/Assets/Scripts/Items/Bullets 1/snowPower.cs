using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowPower : MonoBehaviour {
     Rigidbody2D rb2d;
    public GameObject player;
    public float timeToDestroy;
    private float firstTime;
    public bool slowed = false;
    // Use this for initialization
	void Start () {
        player = (GameObject.Find("Player"));
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

            player.AddComponent<Slow>();

            Destroy(GameObject.Find(this.gameObject.name));

        }
    }
}
