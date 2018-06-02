using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperRunner : MonoBehaviour {
    public PlayerController player;
    public float timeToDestroy = 5;
    private float firstTime = 5;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        player.speed = player.speed + 450;
        player.boosted = true;
        player.runner = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {

            player.speed = player.speed - 450;
            player.boosted = false;
            player.runner = false;
            timeToDestroy = firstTime;
            Destroy(this);

        }
    }
}
