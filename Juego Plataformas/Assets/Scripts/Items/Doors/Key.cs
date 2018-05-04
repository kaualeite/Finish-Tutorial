using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerController player;
    public GameObject door;
    public Transform targets;
    // Use this for initialization
    public Vector3 start;
    public Vector3 end;
    public float positionx = 0;
    public float positiony = 0;
    void Start()
    {

        start = transform.position;
        end = targets.position;
        positionx = end.x;
        positiony = end.y;

    }
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player")
        {

           
            if (player.keyNumber > 0)
            {

                player.porterx = positionx;
                player.portery = positiony;
                player.Playerusekeydoor();


            }
            else
            {
                //else elsoso


            }
        }
    }
}