using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public PlayerController player;
    public lightInvoker invokation;

    public float timeToDestroy = 2;
    private float firstTime = 2;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);
        invokation = GetComponentInParent<lightInvoker>();
        player.changeStatus = true;
        player.lightned = true;
        invokation.invoked = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {

            invokation.invoked = false;
            player.changeStatus = false;
            player.lightned = false;
            timeToDestroy = firstTime;
            Destroy(this);

        }
    }
}
