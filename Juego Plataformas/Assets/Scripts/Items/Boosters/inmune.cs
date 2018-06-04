using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inmune : MonoBehaviour {

    public PlayerController player;
 
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController);

        player.boosted = true;
        player.inmunity = true;
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
