using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpIncrement : MonoBehaviour {
    public PlayerController player;
    public float timeToDestroy = 2;
    private float firstTime = 2;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        player.jumpPower = player.jumpPower + 5;
        player.boosted = true;
        player.jumper = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {

            player.jumpPower = player.jumpPower - 5;
            player.boosted = false;
            player.jumper = false;
            timeToDestroy = firstTime;
            Destroy(this);

        }
    }
}
