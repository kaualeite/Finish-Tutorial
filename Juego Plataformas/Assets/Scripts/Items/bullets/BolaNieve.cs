using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaNieve : MonoBehaviour 
{	
    public PlayerController player;

	// Use this for initialization
	void Start () 
	{
        player = GetComponentInParent<PlayerController>();    
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nieve")
        {
            player.maxSpeed = player.maxSpeed -2;
            Destroy(GameObject.Find(other.gameObject.name));
            player.grounded = true;
        }
    }
}
